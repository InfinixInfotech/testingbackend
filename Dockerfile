# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy all project files
COPY ["InfinixInfotech/InfinixInfotech.csproj", "InfinixInfotech/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Services/Services.csproj", "Services/"]

# Restore dependencies
RUN dotnet restore "InfinixInfotech/InfinixInfotech.csproj"

# Copy the entire solution
COPY . .

# Publish the application in Release mode
RUN dotnet publish "InfinixInfotech/InfinixInfotech.csproj" -c Release -o /app/publish

# Use the official .NET runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 5119


# Copy the published app from the build image
COPY --from=build /app/publish .

# Define the entry point for the container
ENTRYPOINT ["dotnet", "InfinixInfotech.dll"]
