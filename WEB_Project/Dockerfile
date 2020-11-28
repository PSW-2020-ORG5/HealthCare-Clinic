# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY ..
EXPOSE 80
ENTRYPOINT ["dotnet", "Health_Clinic_Web_App.dll"]