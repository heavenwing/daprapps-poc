package daprapps.poc.basicsetting.model.response;

import java.util.List;
import java.util.UUID;

public class BizScopeAllowResp {
    private List<UUID> items;

    public List<UUID> getItems() {
        return items;
    }

    public void setItems(List<UUID> items) {
        this.items = items;
    }
}
