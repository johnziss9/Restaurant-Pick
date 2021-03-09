FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Restaurant-Picker.csproj", "./"]
RUN dotnet restore "Restaurant-Picker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Restaurant-Picker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaurant-Picker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurant-Picker.dll"]
