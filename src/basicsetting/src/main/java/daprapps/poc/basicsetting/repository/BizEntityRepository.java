package daprapps.poc.basicsetting.repository;

import daprapps.poc.basicsetting.model.entity.BizEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.UUID;

@Repository
public interface BizEntityRepository extends JpaRepository<BizEntity, UUID>, JpaSpecificationExecutor<BizEntity> {

        List<BizEntity> findByBizEntityIdAndProductIdIn(UUID bizId, List<UUID> productIds);

        @Query(value = "select * " +
                        "from (select * from biz_entity where biz_entity_id = ?1) as b1 " +
                        "inner join (select * from biz_entity where biz_entity_id = ?2) as b2 " +
                        "on b1.product_id = b2.product_id", nativeQuery = true)
        List<BizEntity> findBothInCompanyIdAndProviderId(UUID companyId, UUID providerId);
}