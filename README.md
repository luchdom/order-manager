Sample implementation of an orders manager API with good practices

## What will you see
- DDD
- CQRS
- Events
- Monitoring (logs, health checks)
- Authentication and authorization
- Resiliency policies
- Fail fast validations
- EF Core Code First
- Integration and Unit Tests

## Getting Started

Run on base project folder to update database
```
dotnet ef database update
```

To add a new migration
```
dotnet ef migrations add <name> --context OrderManager.Api.Infra.AppDbContext -o Data/Migrations
```
