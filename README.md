# olih-api

Back end api for OLIH solution

## For multiple migrations:

### A - MIGRATION
        1. Go to root folder: cd ./olih-api
        2. run shell command:

        ```
        dotnet ef -s Olih.Api/Olih.Api.csproj migrations add -c OlihDbContext  Init  -p Olih.Infrastructure/Olih.Infrastructure.csproj
        ```

        -s : startup project
        -p : entity project
        -c: database context name

### B - DB APPLY

        1. run shell command:
        ```
        dotnet ef database update -s Olih.Api/Olih.Api.csproj -c OlihDbContext  -p Olih.Infrastructure/Olih.Infrastructure.csproj
        ```