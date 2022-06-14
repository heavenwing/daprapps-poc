$env:ASPNETCORE_URLS="http://+:8083"

dapr run `
    --app-id godown --app-port 8083 `
    --dapr-http-port 3503 --dapr-grpc-port 10003 `
    --metrics-port 9093 --components-path "../../components/local" -- `
    dotnet run --project "../../src/godown/godown.csproj"