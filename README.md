# Item Price Updates App

A ASP.NET Core API, ASP.NET Core SignalR Backend.

## Tech Stack

- Backend: C#, ASP.NET Core Web API, ASP.NET Core SignalR
- Swagger: Open API Specification
- Communication: WebSocket

### Backend

- Real-time price updates via WebSocket using ASP.NET Core SignalR
- Price change indicators (up/down/same)
- Subscribe/Unsubscribe toggle
- Minimal network traffic using ASP.NET Core SignalR to push price changes to the client
- The ASP.NET Core app uses a background service every second to randomly generate item prices
- The items are pushed to subscribed clients

To start backend:

```bash

cd ItemPrice.API\src\ItemPrice.API

dotnet restore && dotnet run
```

## Improvements required

- Add authentication and authorisation
- Add unit and integration tests
- Use configurations from appsettings.json
- Remove hardcoded URL
- Use a database, e.g, SQL Server for the data source
- Use Domain Driven Design
