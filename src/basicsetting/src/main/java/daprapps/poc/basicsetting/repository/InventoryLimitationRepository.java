package daprapps.poc.basicsetting.repository;

import daprapps.poc.basicsetting.model.entity.InventoryLimitation;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.UUID;

@Repository
public interface InventoryLimitationRepository
        extends JpaRepository<InventoryLimitation, UUID>, JpaSpecificationExecutor<InventoryLimitation> {
    List<InventoryLimitation> findByCompanyId(UUID companyId);

    List<InventoryLimitation> findByCompanyIdAndProductIdIn(UUID companyId, List<UUID> products);
}