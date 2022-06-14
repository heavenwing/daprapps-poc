package daprapps.poc.basicinfo.config;

import org.springframework.http.MediaType;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;

import java.util.ArrayList;
import java.util.List;

public class CustomMappingJackson2HttpMessageConverter extends MappingJackson2HttpMessageConverter {

    public CustomMappingJackson2HttpMessageConverter() {
        List<MediaType> mediaTypes = new ArrayList<MediaType>();
        mediaTypes.add(MediaType.APPLICATION_JSON);
        setSupportedMediaTypes(mediaTypes);
    }
}
