# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copie o arquivo de solução .sln para o diretório de build
COPY ./controle-financeiro-api.sln ./

# Copie o arquivo de projeto .csproj para o diretório de build
COPY ./controle-financeiro-api/controle-financeiro-api.csproj ./controle-financeiro-api/

# Restaure as dependências do projeto
RUN dotnet restore ./controle-financeiro-api.sln

# Copie o restante do código-fonte
COPY . .

# Publique o projeto
RUN dotnet publish ./controle-financeiro-api/controle-financeiro-api.csproj -c Release -o /app/publish

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "controle-financeiro-api.dll"]
