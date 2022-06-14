package daprapps.poc.basicsetting.model.request;

import java.io.Serializable;
import java.util.UUID;

public class BizScopeAllowableReq implements Serializable {

    private UUID companyId;
    private UUID providerId;

    public UUID getCompanyId() {
        return companyId;
    }

    public void setCompanyId(UUID companyId) {
        this.companyId = companyId;
    }

    public UUID getProviderId() {
        return providerId;
    }

    public void setProviderId(UUID providerId) {
        this.providerId = providerId;
    }
}
