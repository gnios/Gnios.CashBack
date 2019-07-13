FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Gnios.CashBack.Api/Gnios.CashBack.Api.csproj", "Gnios.CashBack.Api/"]
RUN dotnet restore "Gnios.CashBack.Api/Gnios.CashBack.Api.csproj"
COPY . .
WORKDIR "/src/Gnios.CashBack.Api"
RUN dotnet build "Gnios.CashBack.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Gnios.CashBack.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Gnios.CashBack.Api.dll"]