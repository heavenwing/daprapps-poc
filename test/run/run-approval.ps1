$env:ASPNETCORE_URLS="http://+:8085"

dapr run `
    --app-id approval --app-port 8085 `
    --dapr-http-port 3505 --dapr-grpc-port 10005 `
    --metrics-port 9095 --components-path "../../components/local" -- `
    dotnet run --project "../../src/approval/approval.csproj"