package daprapps.poc.basicinfo.model.second.response;

import java.io.Serializable;
import java.util.Map;
import java.util.UUID;

public class CompanyNameResp implements Serializable {
    private Map<UUID, String> items;

    public Map<UUID, String> getItems() {
        return items;
    }

    public void setItems(Map<UUID, String> items) {
        this.items = items;
    }
}
