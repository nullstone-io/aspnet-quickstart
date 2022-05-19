FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
# Install packages
COPY *.csproj .
RUN dotnet restore
# Copy the rest of app and publish
COPY . .
RUN dotnet publish -c Release -o /app/publish --no-restore


FROM nullstone/dotnet
COPY --from=build /app/publish .
CMD ["dotnet", "aspnet-quickstart.dll"]
