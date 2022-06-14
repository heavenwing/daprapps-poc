dapr run `
    --app-id basicinfo --app-port 8081 `
    --dapr-http-port 3501 --dapr-grpc-port 10001 `
    --metrics-port 9091 --components-path "../../components/local" -- `
    mockoon-cli start --data ./basicinfo.json --daemon-off