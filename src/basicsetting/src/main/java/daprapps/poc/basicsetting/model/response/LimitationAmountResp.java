package daprapps.poc.basicsetting.model.response;

import java.io.Serializable;
import java.util.Map;
import java.util.UUID;

public class LimitationAmountResp implements Serializable {

    private Map<UUID, Long> items;

    public Map<UUID, Long> getItems() {
        return items;
    }

    public void setItems(Map<UUID, Long> items) {
        this.items = items;
    }
}
