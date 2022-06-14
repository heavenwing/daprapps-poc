package daprapps.poc.basicinfo.controller;

import daprapps.poc.basicinfo.model.second.entity.Company;
import daprapps.poc.basicinfo.model.second.request.CompanyNamesQueryReq;
import daprapps.poc.basicinfo.model.second.response.CompanyListResp;
import daprapps.poc.basicinfo.model.second.response.CompanyNameResp;
import daprapps.poc.basicinfo.service.CompanyService;
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
@RequestMapping(value = "/api/Company")
public class CompanyController {

    private final Log log = LogFactory.getLog(CompanyController.class);

    @Autowired
    private CompanyService companyService;

    @PostMapping("/List")
    public ResponseEntity<CompanyListResp> listProduct() {
        var resp = companyService.listAll();
        return ResponseEntity.ok(resp);
    }

    @PostMapping("/Add")
    public ResponseEntity<?> addCompany(@RequestBody Company company) {
        try {
            if (ObjectUtils.isEmpty(company) ||
                    ObjectUtils.isEmpty(company.getId()) ||
                    ObjectUtils.isEmpty(company.getName())) {
                return ResponseEntity.badRequest().build();
            }
            company.setCreateBy("sys");
            company.setUpdateBy("sys");
            company.setCreateTime(Instant.now());
            companyService.saveCompany(company);
        } catch (Exception exception) {
            log.error(exception);
            return ResponseEntity.internalServerError().build();
        }
        return ResponseEntity.ok().build();
    }

    @PostMapping("/Update")
    public ResponseEntity<?> updateCompany(@RequestBody Company company) {
        try {
            if (ObjectUtils.isEmpty(company) ||
                    ObjectUtils.isEmpty(company.getId()) ||
                    ObjectUtils.isEmpty(company.getName())) {
                return ResponseEntity.badRequest().build();
            }
            companyService.updateCompany(company);
        } catch (Exception exception) {
            log.error(exception);
            return ResponseEntity.internalServerError().build();
        }
        return ResponseEntity.ok().build();
    }

    @PostMapping("/GetNames")
    public ResponseEntity<CompanyNameResp> getCompanyNames(@RequestBody CompanyNamesQueryReq req) {
        try {
            if (ObjectUtils.isEmpty(req) || null == req.getIds()) {
                return ResponseEntity.badRequest().build();
            }
            CompanyNameResp companyNameResp = companyService.findCompanyNamesByIdIn(req);
            return ResponseEntity.ok(companyNameResp);
        } catch (Exception exception) {
            log.error(exception);
            return ResponseEntity.internalServerError().build();
        }
    }

}
