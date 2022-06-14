package daprapps.poc.basicinfo.controller;

import daprapps.poc.basicinfo.model.third.request.ProviderNamesQueryReq;
import daprapps.poc.basicinfo.model.third.response.ProviderListResp;
import daprapps.poc.basicinfo.model.third.response.ProviderNamesResp;
import daprapps.poc.basicinfo.model.third.response.ProviderPo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpMethod;
import org.springframework.http.RequestEntity;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.stream.Collectors;

@RestController
@RequestMapping(value = "/api/Provider")
public class ProviderController {

    private final Log log = LogFactory.getLog(ProviderController.class);
    @Autowired
    private RestTemplate restTemplate;

    @Value("${provider.service.enable}")
    private boolean enableProviderService;

    @Value("${provider.service.host}")
    private String providerServiceHost;

    @PostMapping("/GetNames")
    public ResponseEntity<ProviderNamesResp> getProviderNames(@RequestBody ProviderNamesQueryReq req) {
        try {
            // call provider old service to retrieve data
            if (enableProviderService) {
                return getResultFromOldProviderService(req);
            } else {
                return ResponseEntity.ok(queryNames(req.getIds()));
            }

        } catch (Exception exception) {
            log.error(exception);
            return ResponseEntity.internalServerError().build();
        }
    }

    @PostMapping("/List")
    public ResponseEntity<ProviderListResp> listProviders() {
        try {
            return ResponseEntity.ok(initProviders());
        } catch (Exception exception) {
            log.error(exception);
            return ResponseEntity.internalServerError().build();
        }
    }

    private ResponseEntity<ProviderNamesResp> getResultFromOldProviderService(ProviderNamesQueryReq req) {
        HttpEntity<ProviderNamesQueryReq> entity = new HttpEntity<>(req);
        return restTemplate.exchange(
                providerServiceHost + "/api/Provider/GetNames",
                HttpMethod.POST,
                entity,
                new ParameterizedTypeReference<>() {
                });
    }

    private ProviderNamesResp queryNames(List<UUID> ids) {
        ProviderNamesResp resp = new ProviderNamesResp();
        var all = initProviders().getItems();
        Map<UUID, String> items = all.stream().filter(providerPo -> ids.contains(providerPo.getId()))
                .collect(Collectors.toMap(ProviderPo::getId, ProviderPo::getName));
        resp.setItems(items);
        return resp;
    }

    private ProviderListResp initProviders() {
        ProviderPo p1 = new ProviderPo();
        p1.setId(UUID.fromString("6ab52964-2fbb-499a-8a0f-1eebdfebafed"));
        p1.setName("Provider B");

        ProviderPo p2 = new ProviderPo();
        p2.setId(UUID.fromString("0fef67d5-66f7-4e49-b711-2723008716eb"));
        p2.setName("Provider A");

        ProviderPo p3 = new ProviderPo();
        p3.setId(UUID.fromString("9a7ea452-b6d1-4466-8e73-c14763f84189"));
        p3.setName("Provider C");

        List<ProviderPo> items = List.of(p1, p2, p3);
        ProviderListResp resp = new ProviderListResp();
        resp.setItems(items);
        return resp;
    }
}
