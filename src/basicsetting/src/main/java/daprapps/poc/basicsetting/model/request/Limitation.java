package daprapps.poc.basicsetting.model.request;

import java.util.UUID;

public class Limitation {

    private UUID productId;
    private Long amount;

    public UUID getProductId() {
        return productId;
    }

    public void setProductId(UUID productId) {
        this.productId = productId;
    }

    public Long getAmount() {
        return amount;
    }

    public void setAmount(Long amount) {
        this.amount = amount;
    }
}
