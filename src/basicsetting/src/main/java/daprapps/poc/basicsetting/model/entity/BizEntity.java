package daprapps.poc.basicsetting.model.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import java.util.UUID;

@Entity
@Table(name = "biz_entity")
public class BizEntity extends BaseEntity {
    @Id
    @Column(name = "id", nullable = false)
    private UUID id;

    // could be company_id or supplier_id
    @Column(name = "biz_entity_id", nullable = false)
    private UUID bizEntityId;

    @Column(name = "product_id", nullable = false)
    private UUID productId;

    public UUID getProductId() {
        return productId;
    }

    public void setProductId(UUID productId) {
        this.productId = productId;
    }

    public UUID getBizEntityId() {
        return bizEntityId;
    }

    public void setBizEntityId(UUID bizEntityId) {
        this.bizEntityId = bizEntityId;
    }

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }
}