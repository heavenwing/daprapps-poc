package daprapps.poc.basicsetting.controller;

import daprapps.poc.basicsetting.model.request.BizScopeAllowableReq;
import daprapps.poc.basicsetting.model.request.BizScopeSaveReq;
import daprapps.poc.basicsetting.model.response.BizScopeAllowResp;
import daprapps.poc.basicsetting.model.response.BizScopeListResp;
import daprapps.poc.basicsetting.service.BizScopeService;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.util.ObjectUtils;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Optional;

@RestController
@RequestMapping(value = "/api/BizScope")
public class BizScopeController {

    private final Log log = LogFactory.getLog(BizScopeController.class);

    @Autowired
    private BizScopeService bizScopeService;

    @PostMapping("/List")
    public ResponseEntity<BizScopeListResp> listLimitation() {
        var resp = bizScopeService.listAll();
        return ResponseEntity.of(Optional.of(resp));
    }

    @PostMapping("/Save")
    public ResponseEntity<?> SaveLimitations(@RequestBody BizScopeSaveReq req) {
        try {
            if (ObjectUtils.isEmpty(req) ||
                    ObjectUtils.isEmpty(req.getBizEntityId()) ||
                    ObjectUtils.isEmpty(req.getProductIds())) {
                return ResponseEntity.badRequest().build();
            }

            bizScopeService.saveBizScopes(req);

        } catch (Exception ex) {
            log.error(ex);
            return ResponseEntity.internalServerError().build();
        }
        return ResponseEntity.ok().build();
    }

    @PostMapping("/GetAllowable")
    public ResponseEntity<BizScopeAllowResp> GetAllowable(@RequestBody BizScopeAllowableReq req) {
        try {
            if (ObjectUtils.isEmpty(req) ||
                    ObjectUtils.isEmpty(req.getCompanyId()) ||
                    ObjectUtils.isEmpty(req.getProviderId())) {
                return ResponseEntity.badRequest().build();
            }
            var resp = bizScopeService.getAllowable(req);
            return ResponseEntity.of(Optional.of(resp));
        } catch (Exception ex) {
            log.error(ex);
            return ResponseEntity.internalServerError().build();
        }
    }
}
