package daprapps.poc.basicsetting.model.response;

import daprapps.poc.basicsetting.model.request.LimitationSaveReq;

import java.io.Serializable;
import java.util.List;

public class LimitationResp implements Serializable {

    private List<LimitationSaveReq> items;

    public List<LimitationSaveReq> getItems() {
        return items;
    }

    public void setItems(List<LimitationSaveReq> items) {
        this.items = items;
    }
}
