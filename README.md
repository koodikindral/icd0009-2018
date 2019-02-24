Documentation: docs/scope_of_work.pdf

Building and running Docker image:

```
$ docker build -t webapp .
$ docker run -d -p 8080:80 --name webapp webapp
```

Running DB migrations
```
dotnet ef migrations add InitialDbCreation --project DAL --startup-project WebApp
dotnet ef database update --project DAL --startup-project WebApp
dotnet ef database drop --project DAL --startup-project WebApp

```
Creating REST controllers
```
dotnet aspnet-codegenerator controller -name UserController -actions -m User -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
```
