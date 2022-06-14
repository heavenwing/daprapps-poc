package daprapps.poc.old.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.util.ObjectUtils;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import daprapps.poc.old.model.ProviderListResp;
import daprapps.poc.old.model.ProviderNamesResp;
import daprapps.poc.old.model.ProviderPo;
import daprapps.poc.old.model.ProviderQueryReq;

import java.util.*;
import java.util.stream.Collectors;

@RestController
@RequestMapping(value = "/api/Provider")
public class ProviderController {

    @PostMapping("/List")
    public ResponseEntity<?> listAll() {

        return ResponseEntity.ok(initProviders());
    }

    @PostMapping("/GetNames")
    public ResponseEntity<?> getNames(@RequestBody ProviderQueryReq req) {

        if (ObjectUtils.isEmpty(req) || null == req.getIds()) {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.ok(queryNames(req.getIds()));
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
