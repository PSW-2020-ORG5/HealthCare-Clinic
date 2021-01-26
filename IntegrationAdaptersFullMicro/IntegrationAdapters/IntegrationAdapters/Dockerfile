# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /appIntegration
COPY . .
ENTRYPOINT ["dotnet", "IntegrationAdapters.dll"]