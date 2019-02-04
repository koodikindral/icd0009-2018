Building and running Docker image:

```
$ docker build -t webapp .
$ docker run -d -p 8080:80 --name webapp webapp
```
