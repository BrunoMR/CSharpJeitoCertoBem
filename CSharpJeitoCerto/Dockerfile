FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CSharpJeitoCerto/CSharpJeitoCerto.csproj", "CSharpJeitoCerto/"]
RUN dotnet restore "CSharpJeitoCerto/CSharpJeitoCerto.csproj"
COPY . .
WORKDIR "/src/CSharpJeitoCerto"
RUN dotnet build "CSharpJeitoCerto.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CSharpJeitoCerto.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpJeitoCerto.dll"]
