# Dapr cloud native apps POC

## Prerequisites

- Visual Studio Code
- .NET 6 SDK
- Dapr CLI (maybe need VPN), and initial Dapr self-host environment
- Open JDK 11, like [Microsoft Build of OpenJDK](https://docs.microsoft.com/en-us/java/openjdk/download#openjdk-11)
- Apache Maven 3.x
- Docker for Desktop
- Mockoon/Mockoon-CLI
- Some VSCode Extensions
  - C# for Visual Studio Code
  - Extension Pack for Java
  - Dapr for Visual Studio Code
  - REST Client
  - Others you like
- Some services (can use container)
  - MongoDB: `docker run --name mongodb -d -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=passpocword mongo`
  - PostregSQL: `docker run --name postgres -p 5432:5432 -e POSTGRES_PASSWORD=passpocword -d postgres`
