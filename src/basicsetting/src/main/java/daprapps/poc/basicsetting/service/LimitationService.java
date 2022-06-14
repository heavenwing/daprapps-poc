package daprapps.poc.basicsetting.service;

import daprapps.poc.basicsetting.model.entity.InventoryLimitation;
import daprapps.poc.basicsetting.model.request.Limitation;
import daprapps.poc.basicsetting.model.request.LimitationAmountReq;
import daprapps.poc.basicsetting.model.request.LimitationSaveReq;
import daprapps.poc.basicsetting.model.response.LimitationAmountResp;
import daprapps.poc.basicsetting.model.response.LimitationResp;
import daprapps.poc.basicsetting.repository.InventoryLimitationRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;

import javax.transaction.Transactional;
import java.time.Instant;
import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;

import static java.util.stream.Collectors.groupingBy;

@Service
public class LimitationService {

    @Autowired
    private InventoryLimitationRepository limitationRepository;

    @Transactional
    public LimitationResp listAll() {
        var all = limitationRepository.findAll();

        LimitationResp resp = new LimitationResp();
        List<LimitationSaveReq> items = new ArrayList<>();
        resp.setItems(items);
        if (!CollectionUtils.isEmpty(all)) {
            Map<UUID, List<InventoryLimitation>> map = all.stream()
                    .collect(groupingBy(InventoryLimitation::getCompanyId));

            for (UUID id : map.keySet()) {
                LimitationSaveReq item = new LimitationSaveReq();
                item.setCompanyId(id);
                List<Limitation> details = new ArrayList<>();
                map.get(id).forEach(p -> details.add(convertLimitationEntityToPo(p)));
                item.setDetails(details);
                resp.getItems().add(item);
            }
        }
        return resp;
    }

    @Transactional
    public List<InventoryLimitation> saveLimitations(LimitationSaveReq req) {
        UUID companyId = req.getCompanyId();
        List<Limitation> details = req.getDetails();
        List<InventoryLimitation> entities = limitationRepository.findByCompanyId(companyId);
        limitationRepository.deleteAll(entities);
        limitationRepository.flush();

        List<InventoryLimitation> toBeSaveList = new ArrayList<>();
        for (Limitation limitation : details) {
            InventoryLimitation newEntity = createEntity(companyId, limitation);
            toBeSaveList.add(newEntity);
        }
        return limitationRepository.saveAll(toBeSaveList);
    }

    @Transactional
    public LimitationAmountResp getAmount(LimitationAmountReq req) {
        var entities = limitationRepository.findByCompanyIdAndProductIdIn(
                req.getCompanyId(),
                req.getProductIds());

        // companyId+productId <=> limitation 1:1, List<InventoryLimitation> size <=1
        Map<UUID, List<InventoryLimitation>> productMap = entities.stream().collect(
                groupingBy(InventoryLimitation::getProductId));

        LimitationAmountResp resp = new LimitationAmountResp();
        Map<UUID, Long> items = new HashMap<>();
        for (UUID productId : req.getProductIds()) {
            if (productMap.containsKey(productId) && productMap.get(productId).size() > 0) {
                items.put(productId, productMap.get(productId).get(0).getAmount());
            } else {
                items.put(productId, -1L);
            }
        }
        resp.setItems(items);
        return resp;
    }

    private InventoryLimitation createEntity(UUID companyId, Limitation limitation) {
        InventoryLimitation entity = new InventoryLimitation();
        entity.setId(UUID.randomUUID());
        entity.setCompanyId(companyId);
        entity.setProductId(limitation.getProductId());
        entity.setAmount(limitation.getAmount());
        entity.setCreateBy("sys");
        entity.setUpdateBy("sys");
        entity.setCreateTime(Instant.now());
        return entity;
    }

    private Limitation convertLimitationEntityToPo(InventoryLimitation entity) {
        Limitation po = new Limitation();
        po.setProductId(entity.getProductId());
        po.setAmount(entity.getAmount());
        return po;
    }

    private InventoryLimitation convertPoToLimitationEntity(Limitation po, InventoryLimitation entity, UUID companyId) {
        entity.setCompanyId(companyId);
        entity.setProductId(po.getProductId());
        entity.setAmount(po.getAmount());
        entity.setUpdateBy("sys");
        return entity;
    }

    // public static void main(String[] args) {
    // List<InventoryLimitation> list = new ArrayList<>();
    // UUID companyId1 = UUID.randomUUID();
    // UUID companyId2 = UUID.randomUUID();
    //
    // InventoryLimitation item1 = new InventoryLimitation();
    // item1.setCompanyId(companyId1);
    // item1.setAmount(100L);
    //
    // InventoryLimitation item2 = new InventoryLimitation();
    // item2.setCompanyId(companyId1);
    // item2.setAmount(190L);
    // InventoryLimitation item3 = new InventoryLimitation();
    // item3.setCompanyId(companyId2);
    // item3.setAmount(190L);
    // list.add(item1);
    // list.add(item2);
    // list.add(item3);
    //
    // var res =
    // list.stream().collect(groupingBy(InventoryLimitation::getCompanyId));
    // }

}
