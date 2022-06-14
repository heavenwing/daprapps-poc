package daprapps.poc.basicsetting.model.response;

import daprapps.poc.basicsetting.model.entity.Product;

import java.io.Serializable;
import java.util.List;

public class ProductListResp implements Serializable {
    private List<Product> items;

    public List<Product> getItems() {
        return items;
    }

    public void setItems(List<Product> items) {
        this.items = items;
    }
}
