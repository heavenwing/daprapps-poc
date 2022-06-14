$env:ASPNETCORE_URLS="http://+:8084"

dapr run `
    --app-id inventory --app-port 8084 `
    --dapr-http-port 3504 --dapr-grpc-port 10004 `
    --metrics-port 9094 --components-path "../../components/local" -- `
    dotnet run --project "../../src/inventory/inventory.csproj"