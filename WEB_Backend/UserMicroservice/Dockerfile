# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY LoginMicroservice/ .
EXPOSE 80
ENTRYPOINT ["dotnet", "UserMicroservice.dll"]