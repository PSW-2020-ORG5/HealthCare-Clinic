# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY . .
EXPOSE 8000
ENTRYPOINT ["dotnet", "IntegrationAdapters.dll"]