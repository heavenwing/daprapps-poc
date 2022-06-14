package daprapps.poc.basicinfo.controller;

import daprapps.poc.basicinfo.model.primary.entity.Product;
import daprapps.poc.basicinfo.model.primary.request.ProductNamesQueryReq;
import daprapps.poc.basicinfo.model.primary.response.ProductListResp;
import daprapps.poc.basicinfo.model.primary.response.ProductNameResp;
import daprapps.poc.basicinfo.service.ProductService;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.util.ObjectUtils;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.time.Instant;

@RestController
@RequestMapping(value = "/api/Product")
public class ProductController {

    private final Log log = LogFactory.getLog(ProductController.class);
    @Autowired
    private ProductService productService;

    @PostMapping("/List")
    public ResponseEntity<ProductListResp> listProduct() {
        var resp = productService.listAll();
        return ResponseEntity.ok(resp);
    }

    @PostMapping("/Add")
    public ResponseEntity<?> addProduct(@RequestBody Product product) {
        try {
            if (ObjectUtils.isEmpty(product) ||
                    ObjectUtils.isEmpty(product.getId()) ||
                    ObjectUtils.isEmpty(product.getName()) ||
                    ObjectUtils.isEmpty(product.getIsExempted())) {
                return ResponseEntity.badRequest().build();
            }
            product.setCreateBy("sys");
            product.setUpdateBy("sys");
            product.setCreateTime(Instant.now());
            productService.saveProduct(product);
        } catch (Exception exception) {
            log.error(exception);
            return ResponseEntity.internalServerError().build();
        }
        return ResponseEntity.ok().build();
    }

    @PostMapping("/Update")
    public ResponseEntity<?> updateProduct(@RequestBody Product product) {
        try {
            if (ObjectUtils.isEmpty(product) ||
                    ObjectUtils.isEmpty(product.getId()) ||
                    ObjectUtils.isEmpty(product.getName()) ||
                    ObjectUtils.isEmpty(product.getIsExempted())) {
                return ResponseEntity.badRequest().build();
            }
            productService.updateProduct(product);
        } catch (Exception exception) {
            log.error(exception);
            return ResponseEntity.internalServerError().build();
        }
        return ResponseEntity.ok().build();
    }

    @PostMapping("/GetNames")
    public ResponseEntity<ProductNameResp> getProductNames(@RequestBody ProductNamesQueryReq req) {
        try {
            ProductNameResp productNameResp = productService.findProductNamesByIdIn(req);
            return ResponseEntity.ok(productNameResp);
        } catch (Exception exception) {
            log.error(exception);
            return ResponseEntity.internalServerError().build();
        }
    }

}
