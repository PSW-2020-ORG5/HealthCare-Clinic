# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY . .
EXPOSE 80
ENTRYPOINT ["dotnet", "APIGateway.dll"]