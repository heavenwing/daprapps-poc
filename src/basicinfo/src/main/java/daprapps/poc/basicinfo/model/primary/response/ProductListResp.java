package daprapps.poc.basicinfo.model.primary.response;

import daprapps.poc.basicinfo.model.primary.entity.Product;

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
