#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExamProjectMicroservice/src/TezYordam/TezYordam.Web/TezYordam.Web.csproj", "ExamProjectMicroservice/src/TezYordam/TezYordam.Web/"]
COPY ["ExamProjectMicroservice/src/TezYordam/TezYordam.Application/TezYordam.Application.csproj", "ExamProjectMicroservice/src/TezYordam/TezYordam.Application/"]
COPY ["ExamProjectMicroservice/src/TezYordam/TezYordam.Domain/TezYordam.Domain.csproj", "ExamProjectMicroservice/src/TezYordam/TezYordam.Domain/"]
COPY ["ExamProjectMicroservice/src/TezYordam/TezYordam.Infrastructure/TezYordam.Infrastructure.csproj", "ExamProjectMicroservice/src/TezYordam/TezYordam.Infrastructure/"]
RUN dotnet restore "ExamProjectMicroservice/src/TezYordam/TezYordam.Web/TezYordam.Web.csproj"
COPY . .
WORKDIR "/src/ExamProjectMicroservice/src/TezYordam/TezYordam.Web"
RUN dotnet build "TezYordam.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TezYordam.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TezYordam.Web.dll"]