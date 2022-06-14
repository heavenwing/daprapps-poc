package daprapps.poc.basicinfo.repository.primary;

import daprapps.poc.basicinfo.model.primary.entity.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.UUID;

@Repository
public interface ProductRepository extends JpaRepository<Product, UUID>, JpaSpecificationExecutor<Product> {

    public List<Product> findProductsByIdIn(List<UUID> ids);
}