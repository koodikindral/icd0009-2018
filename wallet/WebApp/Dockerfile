FROM microsoft/dotnet:sdk AS build-env
WORKDIR /wallet

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /wallet
COPY --from=build-env /wallet/out .
ENTRYPOINT ["dotnet", "WebApp.dll"]