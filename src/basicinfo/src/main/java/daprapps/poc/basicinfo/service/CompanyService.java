package daprapps.poc.basicinfo.service;

import daprapps.poc.basicinfo.model.second.entity.Company;
import daprapps.poc.basicinfo.model.second.request.CompanyNamesQueryReq;
import daprapps.poc.basicinfo.model.second.response.CompanyListResp;
import daprapps.poc.basicinfo.model.second.response.CompanyNameResp;
import daprapps.poc.basicinfo.repository.second.CompanyRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;

import java.util.*;
import java.util.stream.Collectors;

@Service
public class CompanyService {

    @Autowired
    private CompanyRepository companyRepository;

    public CompanyListResp listAll() {
        var items = companyRepository.findAll();
        CompanyListResp resp = new CompanyListResp();
        resp.setItems(items);
        return resp;
    }

    public CompanyNameResp findCompanyNamesByIdIn(CompanyNamesQueryReq req) {

        var companies = companyRepository.findCompaniesByIdIn(req.getIds());
        CompanyNameResp resp = new CompanyNameResp();
        Map<UUID, String> items = new HashMap<>();
        if (!CollectionUtils.isEmpty(companies)) {
            items = companies.stream().collect(Collectors.toMap(Company::getId, Company::getName));
        }
        resp.setItems(items);
        return resp;
    }

    public Company saveCompany(Company company) {
        return companyRepository.save(company);
    }

    public Optional<Company> findById(UUID id) {
        return companyRepository.findById(id);
    }

    public Company updateCompany(Company company) {
        var p = findById(company.getId());
        if (p.isPresent()) {
            var pe = p.get();
            pe.setId(company.getId());
            pe.setName(company.getName());
            return companyRepository.save(pe);
        } else {
            return null;
        }
    }
}
