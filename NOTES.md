## Building an End-to-end SPA Using ASP.NET Core 6 Web API and React

- OVERVIEW:
  - Leveraging Minimal APIs.
  - Coding a REACT application.
  - Securing both applications.

- FIRST STEPS:
  - SPA: ASP.NET Core 6 with REACT via TypeScript. Doing versus explaining. Opionated.
  - [GitHub](https://github.com/RolandGuijt/ps-globomantics-webapi-react)
  ```javascript
    dotnet dev-certs https --trust
    dotnet tool install --global dotnet-ef
    dotnet ef database update
    dotnet run
    npm install
    npm audit fix
    npm start
  ```
  - INIT:
  ```javascript
    npx create-react-app@5 ui --template typescript
    npm start
    npm install bootstrap@5
    dotnet new webapi -minimal
  ```