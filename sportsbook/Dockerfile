FROM microsoft/dotnet:sdk AS build-env
ARG APP_NAME
ENV APP_NAME=${APP_NAME:-SportsbookApp} 
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY /$APP_NAME/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish $APP_NAME -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
ARG APP_NAME
ENV APP_NAME=${APP_NAME:-SportsbookApp} 
WORKDIR /app
COPY --from=build-env /app/$APP_NAME/out .
ENTRYPOINT dotnet $APP_NAME.dll