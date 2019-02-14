Building and running Docker image:

```
$ docker build -t webapp .
$ docker run -d -p 8080:80 --name webapp webapp
```

Running DB migrations
```
dotnet ef migrations add InitialCreate --project DAL
dotnet ef database update --project DAL
```
