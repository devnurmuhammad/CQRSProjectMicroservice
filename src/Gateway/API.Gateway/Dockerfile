#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExamProjectMicroservice/src/Gateway/API.Gateway/API.Gateway.csproj", "ExamProjectMicroservice/src/Gateway/API.Gateway/"]
RUN dotnet restore "ExamProjectMicroservice/src/Gateway/API.Gateway/API.Gateway.csproj"
COPY . .
WORKDIR "/src/ExamProjectMicroservice/src/Gateway/API.Gateway"
RUN dotnet build "API.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Gateway.dll"]