FROM adoptopenjdk:11-jre

RUN mkdir -p /jflog
RUN mkdir -p /app

ADD ./target/basicinfo-0.0.1-SNAPSHOT.jar /app/

ENV ENVPROFILE="dev"
#ENV SRVPWD="" -Dspring.cloud.config.password=${SRVPWD}
ENV SVC_NAME="basicinfo"
ENV SVC_PORT=8081
ENV DBURL1=""
ENV DBUSER1=""
ENV DBPWD1=""
ENV DBURL2=""
ENV DBUSER2=""
ENV DBPWD2=""
ENV JAVA_OPTS=""
ENV PROVIDER_HOST=""

ENTRYPOINT ["sh","-c","java -jar $JAVA_OPTS -Dspring.profiles.active=${ENVPROFILE} -Dspring.application.name=${SVC_NAME} -Dspring.datasource.primary.jdbc-url=${DBURL1} -Dspring.datasource.primary.username=${DBUSER1} -Dspring.datasource.primary.password=${DBPWD1} -Dspring.datasource.secondary.jdbc-url=${DBURL2} -Dspring.datasource.secondary.username=${DBUSER2} -Dspring.datasource.secondary.password=${DBPWD2} -Dprovider.service.host=${PROVIDER_HOST} /app/basicinfo-0.0.1-SNAPSHOT.jar"]

EXPOSE $SVC_PORT

MAINTAINER chen
# build in dockerfile directory
# docker build -t daprapps-basicinfo/daprapps-basicinfo-docker-file:0.0.1 .

# docker run
# docker run --name docker-daprapps-basicinfo -e DBURL1=jdbc:postgresql://docker.for.mac.host.internal:5432/mdm_product -e DBUSER1=postgres -e DBPWD1=passpocword -e DBURL2=jdbc:postgresql://docker.for.mac.host.internal:5432/mdm_company_legacy -e DBUSER2=postgres -e DBPWD2=passpocword -e JAVA_OPTS="-Dprovider.service.enable=false" daprapps-basicinfo/daprapps-basicinfo-docker-file:0.0.1