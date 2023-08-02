FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["backend_aws_portfolio/backend_aws_portfolio.csproj", "backend_aws_portfolio/"]
RUN dotnet restore "backend_aws_portfolio/backend_aws_portfolio.csproj"
COPY . .
WORKDIR "/src/backend_aws_portfolio"
RUN dotnet build "backend_aws_portfolio.csproj" -c Release -o /app/build

FROM build AS publish
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_14.x | bash \
    && apt-get install nodejs -yq
RUN dotnet publish "backend_aws_portfolio.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend_aws_portfolio.dll"]
