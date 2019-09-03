# AccountAPI
This rest API uses CRUD functions to manage game accounts.

This project uses these dependencies:
- "EntityFrameworkCore.Diagrams": "0.4.2",
- "Microsoft.AspNetCore.App": "2.2.0",
- "Microsoft.AspNetCore.JsonPatch": "2.2.0",
- "Microsoft.AspNetCore.Mvc.Versioning": "3.1.4",
- "Microsoft.AspNetCore.Razor.Design": "2.2.0",
- "Microsoft.NETCore.App": "2.2.0",
- "NLog.Web.AspNetCore": "4.8.2",
- "Pomelo.EntityFrameworkCore.MySql": "2.2.0"


## Project Setup

### Configure appsettings.json
```
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;userid=somname;password=somepassword;port=3306;database=accountapi;SslMode=None"
}
```

### Run migrations
dotnet ef migrations add InitialMigration

### Push Migrations to the DB
dotnet ef database update

### Seed Data  
The seed data is private data that is initialized in the DB when migrations are ran and pushed. Remove the seed data calls in Context.cs if you do not need to include data.
