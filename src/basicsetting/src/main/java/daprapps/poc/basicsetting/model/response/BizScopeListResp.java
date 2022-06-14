package daprapps.poc.basicsetting.model.response;

import java.io.Serializable;
import java.util.List;

public class BizScopeListResp implements Serializable {
    private List<BizScopeResp> items;

    public List<BizScopeResp> getItems() {
        return items;
    }

    public void setItems(List<BizScopeResp> items) {
        this.items = items;
    }
}
