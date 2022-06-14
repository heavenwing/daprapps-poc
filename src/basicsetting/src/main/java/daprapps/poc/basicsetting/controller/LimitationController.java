package daprapps.poc.basicsetting.controller;

import daprapps.poc.basicsetting.model.request.LimitationAmountReq;
import daprapps.poc.basicsetting.model.request.LimitationSaveReq;
import daprapps.poc.basicsetting.model.response.LimitationAmountResp;
import daprapps.poc.basicsetting.model.response.LimitationResp;
import daprapps.poc.basicsetting.service.LimitationService;
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
@RequestMapping(value = "/api/Limitation")
public class LimitationController {

    private final Log log = LogFactory.getLog(LimitationController.class);

    @Autowired
    private LimitationService limitationService;

    @PostMapping("/List")
    public ResponseEntity<LimitationResp> listLimitation() {
        var resp = limitationService.listAll();
        return ResponseEntity.of(Optional.of(resp));
    }

    @PostMapping("/Save")
    public ResponseEntity<?> SaveLimitations(@RequestBody LimitationSaveReq req) {
        try {
            if (ObjectUtils.isEmpty(req) ||
                    ObjectUtils.isEmpty(req.getCompanyId()) ||
                    ObjectUtils.isEmpty(req.getDetails())) {
                return ResponseEntity.badRequest().build();
            }
            var resp = limitationService.saveLimitations(req);
        } catch (Exception ex) {
            log.error(ex);
            return ResponseEntity.internalServerError().build();
        }
        return ResponseEntity.ok().build();
    }

    @PostMapping("/GetAmount")
    public ResponseEntity<LimitationAmountResp> GetAmount(@RequestBody LimitationAmountReq req) {
        try {
            if (ObjectUtils.isEmpty(req) ||
                    ObjectUtils.isEmpty(req.getCompanyId()) ||
                    ObjectUtils.isEmpty(req.getProductIds())) {
                return ResponseEntity.badRequest().build();
            }
            var resp = limitationService.getAmount(req);
            return ResponseEntity.of(Optional.of(resp));
        } catch (Exception ex) {
            log.error(ex);
            return ResponseEntity.internalServerError().build();
        }
    }
}
