package daprapps.poc.basicinfo.model.primary.request;

import java.io.Serializable;
import java.util.List;
import java.util.UUID;

public class ProductNamesQueryReq implements Serializable {

    private List<UUID> ids;

    public List<UUID> getIds() {
        return ids;
    }

    public void setIds(List<UUID> ids) {
        this.ids = ids;
    }

}
