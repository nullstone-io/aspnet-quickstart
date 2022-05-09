# .NET Quickstart

This is an ASP.NET Core Web App Quickstart for [Nullstone](https://nullstone.io).
This is based off the official [ASP.NET Core get started](https://docs.microsoft.com/en-us/aspnet/core/getting-started/?view=aspnetcore-6.0) tutorial.

This quickstart is set up with:
- ASP.NET Core 6
- HTTPS disabled (handled by AWS infrastructure)

## How to launch via Nullstone

1. Create a static site. (Remember `app-name` for later)
2. Add a subdomain. (this will add a Load Balancer capability)
3. Provision
  ```shell
  nullstone up --wait --block=<app-name> --env=<env-name>
  ```
4. Build, push, and deploy
  ```shell
  docker build -t dotnet-quickstart .
  nullstone launch --source=dotnet-quickstart --app=<app-name> --env=<env-name>
  ```

## Running locally

You can run this project locally inside Docker or using a dev server.
The docker setup is configured to hot reload; you don't have to rebuild/restart the container when you change code.

### Docker

```shell
docker compose up
```

Visit [http://localhost:5281](http://localhost:5281).

### Dev Server

```shell
dotnet watch run
```

Visit [http://localhost:5281](http://localhost:5281).

### Hot reload

The `app` in `docker-compose.yml` is configured to automatically reload changes to code.
You do not need to rebuild/restart the app when making changes to code.

### Update dependencies

To make changes to dependencies, make changes to your project and restart your docker container.
`dotnet restore` happens automatically at the boot of the docker container to update dependencies.

```shell
docker compose restart app
```

## Details on quickstart

This web app was generated following these steps.
1. `dotnet new webapp --no-https -o .`
2. `dotnet new gitignore`
