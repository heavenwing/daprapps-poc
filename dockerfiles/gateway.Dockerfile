FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 8091

ENV ASPNETCORE_URLS=http://+:8091

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
COPY /src/AppModels/ /src/AppModels/
COPY /src/gateway/ /src/gateway/
WORKDIR "/src/gateway"
RUN dotnet restore "gateway.csproj"
RUN dotnet build "gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gateway.dll"]
