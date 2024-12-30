# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj and restore dependencies
COPY InfinixInfotech/InfinixInfotech.csproj ./InfinixInfotech/
RUN dotnet restore "InfinixInfotech/InfinixInfotech.csproj"

# Copy the remaining files and publish the application in Release mode
COPY . .
RUN dotnet publish "InfinixInfotech/InfinixInfotech.csproj" -c Release -o /app/publish

# Use the official .NET runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published app from the build image
COPY --from=build /app/publish .

# Define the entry point for the container
ENTRYPOINT ["dotnet", "InfinixInfotech.dll"]
