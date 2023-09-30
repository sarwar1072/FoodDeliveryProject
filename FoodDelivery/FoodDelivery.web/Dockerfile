FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FoodDelivery.web/*.csproj", "FoodDelivery.web/"]
COPY ["Framework/*.csproj", "Framework/"]
COPY ["Membership/*.csproj", "Membership/"]
COPY ["DataAccessLayer/*.csproj", "DataAccessLayer/"]
RUN dotnet restore "FoodDelivery.web/FoodDelivery.web.csproj"
COPY . .
WORKDIR "/src/FoodDelivery.web"
RUN dotnet build "FoodDelivery.web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FoodDelivery.web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FoodDelivery.web.dll"]