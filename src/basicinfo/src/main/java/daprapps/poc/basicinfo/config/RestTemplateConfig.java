package daprapps.poc.basicinfo.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.client.ClientHttpRequestFactory;
import org.springframework.http.client.SimpleClientHttpRequestFactory;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.web.client.RestTemplate;

import java.util.List;

@Configuration
public class RestTemplateConfig {

    private int restTemplateConnectionTimeout = -1;
    private int restTemplateReadTimeout = -1;

    @Bean
    public RestTemplate restTemplate(ClientHttpRequestFactory simpleClientHttpRequestFactory) {
        RestTemplate restTemplate = new RestTemplate();
        // 配置自定义的message转换器
        List<HttpMessageConverter<?>> messageConverters = restTemplate.getMessageConverters();
        messageConverters.add(new CustomMappingJackson2HttpMessageConverter());
        restTemplate.setMessageConverters(messageConverters);
        // 配置自定义的interceptor拦截器
        // List<ClientHttpRequestInterceptor> interceptors=new
        // ArrayList<ClientHttpRequestInterceptor>();
        // interceptors.add(new HeadClientHttpRequestInterceptor());
        // interceptors.add(new TrackLogClientHttpRequestInterceptor());
        // restTemplate.setInterceptors(interceptors);
        // 配置自定义的异常处理
        // restTemplate.setErrorHandler(new CustomResponseErrorHandler());
        restTemplate.setRequestFactory(simpleClientHttpRequestFactory);

        return restTemplate;
    }

    @Bean
    public ClientHttpRequestFactory simpleClientHttpRequestFactory() {
        SimpleClientHttpRequestFactory reqFactory = new SimpleClientHttpRequestFactory();
        reqFactory.setConnectTimeout(restTemplateConnectionTimeout);
        reqFactory.setReadTimeout(restTemplateReadTimeout);
        return reqFactory;
    }

}
