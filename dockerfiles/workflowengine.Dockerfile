FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine3.14 AS base
WORKDIR /app
EXPOSE 8200

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY /src/AppModels/ /src/AppModels/
COPY /src/workflowengine/ /src/workflowengine/
WORKDIR "/src/workflowengine"
RUN dotnet restore "workflowengine.csproj"
RUN dotnet build "workflowengine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "workflowengine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN apk update && apk add --no-cache libc6-compat && \
    ln -s /lib/libc.musl-x86_64.so.1 /lib/ld-linux-x86-64.so.2

RUN chmod +x workflowengine.dll

ENTRYPOINT ["dotnet", "workflowengine.dll", "--workflows-path", "/workflows"]