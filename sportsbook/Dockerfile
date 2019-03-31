FROM microsoft/dotnet:sdk AS build-env
ENV APP ${app}
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY /$APP/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish $APP -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/$APP/out .
ENTRYPOINT ["dotnet", "WebApp.dll"]