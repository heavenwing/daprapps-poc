package daprapps.poc.basicsetting.model.request;

import java.io.Serializable;
import java.util.List;
import java.util.UUID;

public class LimitationSaveReq implements Serializable {

    private UUID companyId;
    private List<Limitation> details;

    public UUID getCompanyId() {
        return companyId;
    }

    public void setCompanyId(UUID companyId) {
        this.companyId = companyId;
    }

    public List<Limitation> getDetails() {
        return details;
    }

    public void setDetails(List<Limitation> details) {
        this.details = details;
    }
}
