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

- EXPOSING, GETTING, & DISPLAYING DATA:
  ```javascript
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.*
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.*
    dotnet ef migrations add initial
    dotnet ef database update
  ```
  - Entities: Only used within API. Use DTOS for transfer.
    - Contain database specifics. 
    - Are meant only to access the database.
    - Do not send them across the wre.
  - Cross-Origin Resource Sharing: CORS
    - By default browser will block HTTP responses from requests initiated in JavaScript.
    - Only when the domain of API is different than the original.
    - Explicitly allow origin by setting an HTTP header on the API response.
  - What's wrong with this?
    - Fetch will occur on each re-render. Costly operation.
    - Only fetch when the component is first renendered.
    - Fetch code should be elsewhere.
  - What's wrong with this?
    - When users stay on the same screen data will remain static.
    - When the custom hook is used in multiple components it will fetch the data each time.
    - We don't have a retry mechanism.
    - SO: We need shared state, caching, controlled re-fetching and retries.
      ```javascript
        npm install axios@0 react-query@3
      ```
    - Cached data will be marked as stale right after fetch.
    - Re-fetch will only occur when new mount of query occurs. 
    - Or the browser refocuses. Or when the network is reconnected.
    - 5 minutes cache. Retry automatically 3x. (React query documentation.)
  - Format the prices.
