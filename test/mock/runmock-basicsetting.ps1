dapr run `
    --app-id basicsetting --app-port 8082 `
    --dapr-http-port 3502 --dapr-grpc-port 10002 `
    --metrics-port 9092 --components-path "../../components/local" -- `
    mockoon-cli start --data ./basicsetting.json --daemon-off