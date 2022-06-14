$env:ASPNETCORE_URLS="http://+:8091"

dapr run `
    --app-id gateway --app-port 8091 `
    --dapr-http-port 3511 --dapr-grpc-port 10011 `
    --metrics-port 9101 --components-path "../../components/local" -- `
    dotnet run --project "../../src/gateway/gateway.csproj"