package daprapps.poc.basicsetting.service;

import io.dapr.client.DaprClient;
import io.dapr.client.DaprClientBuilder;
import io.dapr.client.domain.HttpExtension;

import daprapps.poc.basicsetting.model.entity.BizEntity;
import daprapps.poc.basicsetting.model.entity.Product;
import daprapps.poc.basicsetting.model.request.BizScopeAllowableReq;
import daprapps.poc.basicsetting.model.request.BizScopeSaveReq;
import daprapps.poc.basicsetting.model.response.BizScopeAllowResp;
import daprapps.poc.basicsetting.model.response.BizScopeListResp;
import daprapps.poc.basicsetting.model.response.BizScopeResp;
import daprapps.poc.basicsetting.model.response.ProductListResp;
import daprapps.poc.basicsetting.repository.BizEntityRepository;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.ObjectUtils;

import javax.transaction.Transactional;
import java.time.Instant;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.stream.Collectors;

@Service
public class BizScopeService {

    private final Log log = LogFactory.getLog(BizScopeService.class);

    @Autowired
    private BizEntityRepository bizEntityRepository;

    @Transactional
    public BizScopeListResp listAll() {
        var all = bizEntityRepository.findAll();
        BizScopeListResp resp = new BizScopeListResp();
        List<BizScopeResp> items = new ArrayList<>();
        resp.setItems(items);
        if (!CollectionUtils.isEmpty(all)) {
            Map<UUID, List<BizEntity>> map = all.stream().collect(Collectors.groupingBy(BizEntity::getBizEntityId));

            for (UUID id : map.keySet()) {
                BizScopeResp item = new BizScopeResp();
                item.setBizEntityId(id);
                List<UUID> productIds = new ArrayList<>();
                map.get(id).forEach(p -> productIds.add(p.getProductId()));
                item.setProductIds(productIds);
                resp.getItems().add(item);
            }
        }
        return resp;
    }

    @Transactional
    public List<BizEntity> saveBizScopes(BizScopeSaveReq req) {
        var entities = bizEntityRepository.findByBizEntityIdAndProductIdIn(
                req.getBizEntityId(),
                req.getProductIds());
        bizEntityRepository.deleteAll(entities);
        bizEntityRepository.flush();

        List<BizEntity> toBeSave = new ArrayList<>();
        for (UUID productId : req.getProductIds()) {
            toBeSave.add(createBizEntity(req.getBizEntityId(), productId));
        }
        return bizEntityRepository.saveAll(toBeSave);
    }

    @Transactional
    public BizScopeAllowResp getAllowable(BizScopeAllowableReq req) {
        var allowedEntities = bizEntityRepository.findBothInCompanyIdAndProviderId(req.getCompanyId(),
                req.getProviderId());
        BizScopeAllowResp resp = new BizScopeAllowResp();
        // call product service to get Exempted product
        ProductListResp productListResp = null;
        try {
            DaprClient client = new DaprClientBuilder().build();
            String serviceAppId = "basicinfo";
            String method = "api/Product/List";
            productListResp = client.invokeMethod(serviceAppId, method, null, HttpExtension.POST, ProductListResp.class)
                    .block();

        } catch (Exception exception) {
            log.error(exception);
        }
        List<UUID> bizScopeProducts = new ArrayList<>();
        List<UUID> exemptedProducts = new ArrayList<>();
        if (!ObjectUtils.isEmpty(allowedEntities)) {
            bizScopeProducts = allowedEntities.stream().map(BizEntity::getProductId).collect(Collectors.toList());
        }
        if (!ObjectUtils.isEmpty(productListResp) && !ObjectUtils.isEmpty(productListResp.getItems())) {
            exemptedProducts = productListResp.getItems().stream()
                    .filter(Product::getIsExempted)
                    .map(Product::getId)
                    .collect(Collectors.toList());
        }
        bizScopeProducts.addAll(exemptedProducts);

        resp.setItems(bizScopeProducts.stream().distinct().collect(Collectors.toList()));
        return resp;
    }

    private BizEntity createBizEntity(UUID bizId, UUID productId) {
        BizEntity entity = new BizEntity();
        entity.setBizEntityId(bizId);
        entity.setId(UUID.randomUUID());
        entity.setProductId(productId);
        entity.setCreateBy("sys");
        entity.setCreateTime(Instant.now());
        entity.setUpdateBy("sys");
        return entity;
    }

}
