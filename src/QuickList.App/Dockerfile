FROM mcr.microsoft.com/dotnet/sdk:10.0 AS base
WORKDIR /app
EXPOSE 80

FROM base AS development
COPY . .
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]

FROM base AS build
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS production
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "QuickList.App.dll"]