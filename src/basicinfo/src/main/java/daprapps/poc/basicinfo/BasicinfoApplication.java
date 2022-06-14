package daprapps.poc.basicinfo;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;

@SpringBootApplication
@EntityScan(basePackages = { "daprapps.poc.basicinfo" })
public class BasicinfoApplication {

	public static void main(String[] args) {
		SpringApplication.run(BasicinfoApplication.class, args);
	}
}
