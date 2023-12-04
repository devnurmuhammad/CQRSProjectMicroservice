#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExamProjectMicroservice/src/TurarJoy/TurarJoy.Web/TurarJoy.Web.csproj", "ExamProjectMicroservice/src/TurarJoy/TurarJoy.Web/"]
RUN dotnet restore "ExamProjectMicroservice/src/TurarJoy/TurarJoy.Web/TurarJoy.Web.csproj"
COPY . .
WORKDIR "/src/ExamProjectMicroservice/src/TurarJoy/TurarJoy.Web"
RUN dotnet build "TurarJoy.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TurarJoy.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TurarJoy.Web.dll"]