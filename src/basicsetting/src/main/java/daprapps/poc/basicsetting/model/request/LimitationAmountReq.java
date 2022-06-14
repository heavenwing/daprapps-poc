package daprapps.poc.basicsetting.model.request;

import java.io.Serializable;
import java.util.List;
import java.util.UUID;

public class LimitationAmountReq implements Serializable {

    private UUID companyId;
    private List<UUID> productIds;

    public UUID getCompanyId() {
        return companyId;
    }

    public void setCompanyId(UUID companyId) {
        this.companyId = companyId;
    }

    public List<UUID> getProductIds() {
        return productIds;
    }

    public void setProductIds(List<UUID> productIds) {
        this.productIds = productIds;
    }
}
