FROM mcr.microsoft.com/dotnet/sdk:10.0 AS base
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

EXPOSE 80

# CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]
