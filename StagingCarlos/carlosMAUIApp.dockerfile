FROM mcr.microsoft.com/dotnet/maui/sdk:latest as build
WORKDIR /MauiTickets

EXPOSE 8081

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet build -c Release -o /app/build

FROM build as publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/maui/runtime:latest as runtime

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MauiTickets.dll"]
