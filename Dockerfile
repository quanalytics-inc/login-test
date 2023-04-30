# Set the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the project files and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
