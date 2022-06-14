# ..\..\src\basicinfo\mvnw.cmd clean package -DskipTests=true
dapr run --app-id "basicinfo" --app-port 8081 `
    --components-path "../../components/local" `
    --dapr-grpc-port "10001" --dapr-http-port 3501 --metrics-port "9091" `
    -- java -jar ../../src/basicinfo/target/basicinfo-0.0.1-SNAPSHOT.jar