# latamat02

## Project requirements
- [Git 2.38+](https://git-scm.com/downloads)
- [Dotnet 6.0+](https://dotnet.microsoft.com/en-us/download)

## Project Setup
- Solution/Projects restore
```
dotnet restore
```

- Tools restore
```
dotnet tool restore
```

## Formating
- Check format issues
```
dotnet format --verify-no-changes
```

- Fix format issues
```
dotnet format
```


## Testing
- Run tests (includes restore and build)
```
dotnet test
```

- Run tests generating html report
```
dotnet test -l html
```

- Run tests including coverage report
```
dotnet test --collect:"XPlat Code Coverage"
dotnet reportgenerator -reports:"**/*.cobertura.xml" -targetdir:".coveragereport"
```

## Tech Docs
- https://learn.microsoft.com/en-us/dotnet/fundamentals/
- https://learn.microsoft.com/en-us/dotnet/csharp/
- https://xunit.net/#documentation
- https://git-scm.com/book/en/v2
- https://github.com/dotnet/format

