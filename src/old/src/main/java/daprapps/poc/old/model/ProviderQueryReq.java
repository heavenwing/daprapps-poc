package daprapps.poc.old.model;

import java.util.List;
import java.util.UUID;

public class ProviderQueryReq {

    private List<UUID> ids;

    public List<UUID> getIds() {
        return ids;
    }

    public void setIds(List<UUID> ids) {
        this.ids = ids;
    }
}
