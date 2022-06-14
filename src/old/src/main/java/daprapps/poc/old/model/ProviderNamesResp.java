package daprapps.poc.old.model;

import java.util.Map;
import java.util.UUID;

public class ProviderNamesResp {
    Map<UUID, String> items;

    public Map<UUID, String> getItems() {
        return items;
    }

    public void setItems(Map<UUID, String> items) {
        this.items = items;
    }
}
