package daprapps.poc.basicsetting.model.response;

import java.util.List;
import java.util.UUID;

public class BizScopeResp {
    private UUID bizEntityId;
    private List<UUID> productIds;

    public UUID getBizEntityId() {
        return bizEntityId;
    }

    public void setBizEntityId(UUID bizEntityId) {
        this.bizEntityId = bizEntityId;
    }

    public List<UUID> getProductIds() {
        return productIds;
    }

    public void setProductIds(List<UUID> productIds) {
        this.productIds = productIds;
    }
}
