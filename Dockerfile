FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Form3Api.csproj", "./"]
RUN dotnet restore "./Form3Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Form3Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Form3Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Form3Api.dll"]
