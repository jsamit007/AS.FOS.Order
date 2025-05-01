# Database Migrations

1. Ensure you have installed EFCore tool in your machine otherwise execute following command

```
dotnet tool install --global dotnet-ef
```

2. Go to Sln Project in Powershell and Execute following command to generate the migrations

```
dotnet ef migrations add InitialCommit `
  --project AS.FOS.Order.Persistence `
  --startup-project AS.FOS.Order.API `
  --output-dir Migrations
```

3. Generate DB Script. If you use Idempotant then no matters how many times you execute scripts, it will have the same result every time 

```
dotnet ef migrations script `
  --project AS.FOS.Order.Persistence `
  --startup-project AS.FOS.Order.API `
  --output order.sql `
  --idempotent
```

dotnet ef migrations add InitialCommit `
  --project AS.FOS.Order.Saga.Persistence `
  --startup-project AS.FOS.Order.API `
  --output-dir Migrations `
  --context SagaDBcontext

dotnet ef migrations script `
  --project AS.FOS.Order.Saga.Persistence `
  --startup-project AS.FOS.Order.API `
  --output ./AS.FOS.Order.Saga.Persistence/Scripts/order.sql `
  --idempotent `
  --context SagaDBcontext