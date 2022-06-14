package daprapps.poc.basicinfo.model.second.response;

import daprapps.poc.basicinfo.model.second.entity.Company;

import java.io.Serializable;
import java.util.List;

public class CompanyListResp implements Serializable {
    private List<Company> items;

    public List<Company> getItems() {
        return items;
    }

    public void setItems(List<Company> items) {
        this.items = items;
    }
}
