# Use uma imagem base para .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie todos os arquivos do contexto atual para o contêiner
COPY . .

# Restaure as dependências usando o arquivo .csproj
RUN dotnet restore "controle-financeiro-api.csproj"

# Compile e publique o projeto
RUN dotnet publish "controle-financeiro-api.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "controle-financeiro-api.dll"]
