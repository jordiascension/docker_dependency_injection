FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/core/runtime:2.1 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

#RUN dotnet DependencyInjection.dll

ENTRYPOINT ["dotnet", "DependencyInjection.dll"]
