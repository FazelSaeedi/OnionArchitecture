# Base image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project files to the container
COPY . .

# Restore dependencies and publish the application
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
# WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "ServiceHost.dll"]



# # Base image for building the application
# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# WORKDIR /app

# # Copy the project files to the container
# COPY . .

# # Restore dependencies and publish the application
# # RUN dotnet restore
# # RUN dotnet publish -c Release -o /app/publish

# # Base image for running the application
# FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
# WORKDIR /app

# # Copy the published application from the build stage
# COPY --from=build /app/TTT .


# # Set the entry point for the application
# # ENTRYPOINT ["dotnet", "ServiceHost.dll"]