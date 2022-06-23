FROM adoptopenjdk:11-jre

RUN mkdir -p /jflog
RUN mkdir -p /app

ADD ./target/basicsetting-0.0.1-SNAPSHOT.jar /app/

ENV ENVPROFILE="dev"
#ENV SRVPWD="" -Dspring.cloud.config.password=${SRVPWD}
ENV SVC_NAME="basicsetting"
ENV SVC_PORT=8082
ENV DBURL=""
ENV DBUSER=""
ENV DBPWD=""
ENV JAVA_OPTS=""

EXPOSE $SVC_PORT

ENTRYPOINT ["sh","-c","java -jar $JAVA_OPTS -Dspring.profiles.active=${ENVPROFILE} -Dspring.application.name=${SVC_NAME} -Dspring.datasource.url=${DBURL} -Dspring.datasource.username=${DBUSER} -Dspring.datasource.password=${DBPWD} /app/basicsetting-0.0.1-SNAPSHOT.jar"]

# build in dockerfile directory
# docker build -t daprapps-basicsetting/daprapps-basicsetting-docker-file:0.0.1 .

# docker run
# docker run --name docker-daprapps-basicsetting -e DBURL=jdbc:postgresql://docker.for.mac.host.internal:5432/mdm_setting -e DBUSER=postgres -e DBPWD=passpocword -e JAVA_OPTS="" daprapps-basicsetting/daprapps-basicsetting-docker-file:0.0.1