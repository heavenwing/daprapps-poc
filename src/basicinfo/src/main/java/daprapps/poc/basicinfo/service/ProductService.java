package daprapps.poc.basicinfo.service;

import daprapps.poc.basicinfo.model.primary.response.ProductListResp;
import daprapps.poc.basicinfo.model.primary.response.ProductNameResp;
import daprapps.poc.basicinfo.model.primary.request.ProductNamesQueryReq;
import daprapps.poc.basicinfo.model.primary.entity.Product;
import daprapps.poc.basicinfo.repository.primary.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;

import java.util.*;
import java.util.stream.Collectors;

@Service
public class ProductService {

    @Autowired
    private ProductRepository productRepository;

    public ProductListResp listAll() {

        var items = productRepository.findAll();
        ProductListResp resp = new ProductListResp();
        resp.setItems(items);
        return resp;
    }

    public Product saveProduct(Product product) {
        return productRepository.save(product);
    }

    public Optional<Product> findById(UUID id) {
        return productRepository.findById(id);
    }

    public Product updateProduct(Product product) {
        var p = findById(product.getId());
        if (p.isPresent()) {
            var pe = p.get();
            pe.setId(product.getId());
            pe.setName(product.getName());
            pe.setIsExempted(product.getIsExempted());
            return productRepository.save(pe);
        } else {
            return null;
        }
    }

    public ProductNameResp findProductNamesByIdIn(ProductNamesQueryReq req) {

        var products = productRepository.findProductsByIdIn(req.getIds());
        ProductNameResp resp = new ProductNameResp();
        Map<UUID, String> items = new HashMap<>();
        if (!CollectionUtils.isEmpty(products)) {
            items = products.stream().collect(Collectors.toMap(Product::getId, Product::getName));
        }
        resp.setItems(items);
        return resp;
    }
}
