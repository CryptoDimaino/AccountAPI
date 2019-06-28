# Configure appsettings.json

"ConnectionStrings": {
    "DefaultConnection": "server=localhost;userid=somname;password=somepassword;port=3306;database=accountapi;SslMode=None"
}

### Run migrations
dotnet ef migrations add InitialMigration

### Push Migrations to the DB
dotnet ef database update