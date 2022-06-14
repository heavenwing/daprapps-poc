
dapr run --app-id "basicsetting" --app-port 8082 `
    --components-path "../../components/local" `
    --dapr-grpc-port "10002" --dapr-http-port 3502 --metrics-port "9092" `
    -- java -jar ../../src/basicsetting/target/basicsetting-0.0.1-SNAPSHOT.jar