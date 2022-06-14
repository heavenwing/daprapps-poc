package daprapps.poc.basicsetting;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@SpringBootApplication
@EnableJpaRepositories("daprapps.poc.basicsetting.repository")
@EntityScan(basePackages = { "daprapps.poc.basicsetting.model.entity" })
public class BasicsettingApplication {

    public static void main(String[] args) {
        SpringApplication.run(BasicsettingApplication.class, args);
    }

}
