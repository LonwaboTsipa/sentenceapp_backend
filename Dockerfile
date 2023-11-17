# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the project files to the container
COPY . .

# Build the application
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published output from the build stage to the runtime stage
COPY --from=build /app/out .

# Expose the port that the application will run on
EXPOSE 80

# Define the entry point for the application
ENTRYPOINT ["dotnet", "sentenceapp_backend.dll"]