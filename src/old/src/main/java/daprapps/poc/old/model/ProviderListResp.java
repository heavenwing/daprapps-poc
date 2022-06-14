package daprapps.poc.old.model;

import java.io.Serializable;
import java.util.List;

public class ProviderListResp implements Serializable {
    private List<ProviderPo> items;

    public List<ProviderPo> getItems() {
        return items;
    }

    public void setItems(List<ProviderPo> items) {
        this.items = items;
    }
}
