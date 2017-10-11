#FROM microsoft/aspnetcore:1.1
#ARG source
#WORKDIR /app
#EXPOSE 80
#COPY ${source:-obj/Docker/publish} .
#ENTRYPOINT ["dotnet", "NuPrescriber.dll"]


# Stage 1
FROM microsoft/aspnetcore-build:1.1 AS builder
WORKDIR /source



# caches restore result by copying csproj file separately
COPY *.csproj .
RUN dotnet restore



# copies the rest of your code
COPY . .
RUN dotnet publish --output /app/ --configuration Release



# run database migrations
RUN dotnet ef migrations add InitialCreate
RUN dotnet ef database update



# Stage 2
FROM microsoft/aspnetcore:1.1
WORKDIR /app
VOLUME /app
EXPOSE 80
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "NuPrescriber.dll"]
