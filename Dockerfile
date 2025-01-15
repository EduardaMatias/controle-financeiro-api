# Use uma imagem base para .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

# Especifique o caminho do arquivo de projeto ou solução
RUN dotnet restore "controle-financeiro-api/controle-financeiro-api.csproj"
RUN dotnet publish "controle-financeiro-api/controle-financeiro-api.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "controle-financeiro-api.dll"]
