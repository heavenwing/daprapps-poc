$env:ASPNETCORE_URLS="http://+:8090"

dapr run `
    --app-id portal --app-port 8090 `
    --dapr-http-port 3510 --dapr-grpc-port 10010 `
    --metrics-port 9100 --components-path "../../components/local" -- `
    dotnet run --project "../../src/portal/portal.csproj"