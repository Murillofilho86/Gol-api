FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Gol.WebApi/Gol.WebApi.csproj", "src/Gol.WebApi/"]
RUN dotnet restore "src/Gol.WebApi/Gol.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Gol.WebApi"
RUN dotnet build "Gol.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Gol.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Gol.WebApi.dll"]