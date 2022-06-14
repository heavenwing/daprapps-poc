dapr run `
    --app-id workflows --app-port 8200 --app-protocol grpc `
    --dapr-http-port 3520 --dapr-grpc-port 10020 `
    --metrics-port 9200 --components-path "../../components/local" -- `
    dotnet run --project "../../src/workflowengine" --workflows-path "../../workflows"