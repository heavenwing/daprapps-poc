package daprapps.poc.basicinfo.repository.second;

import daprapps.poc.basicinfo.model.second.entity.Company;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.UUID;

@Repository
public interface CompanyRepository extends JpaRepository<Company, UUID>, JpaSpecificationExecutor<Company> {
    public List<Company> findCompaniesByIdIn(List<UUID> ids);
}