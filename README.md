# latamat02

## Project Setup
- Solution/Projects restore
```
dotnet restore
```

- Tools restore
```
dotnet tool restore
```

## Testing
- Run tests (includes restore and build)
```
dotnet test
```

- Run test including coverage report
```
dotnet test --collect:"XPlat Code Coverage"
dotnet reportgenerator -reports:"**/*.cobertura.xml" -targetdir:".coveragereport"
```