## Getting Started

In the root directory of the project...

1. Install node modules `yarn install` or `npm install`.
2. Restore nuget packages `dotnet restore`.
3. Start development server `yarn start` or `npm start`.

## Next Steps


### Sample Data

Replace the sample data stored in /server/sampleData.js.


### Adding a New Page

1. Create a folder in `/src/app/app-shell` with your angular modules.
2. Add a child route for your page to `/src/app/*.module.ts`.
3. Add a button to the navigation bar in `/src/app/app-shell/nav-bar/nav-bar.component.html`.


### Deployment

If you selected Azure App Service when creating your project, follow these steps:

1. Press `Ctrl + Shift + P` in Windows/Linux or `Shift ⇧ + Command ⌘ + P` in Mac and type/select `Web Template Studio: Deploy App` to start deploying your app.
2. After your project is built, click on "publish" in the pop up on the top middle section of your screen, and then click "Deploy" on the window pop up.
3. Once the deployment is done, click "Browse website" in the notification window on the lower right corner to check out your newly deployed app.

If you did not select Azure App Service and want to create a new Azure App Service web app, follow these steps:

1. Create publish folder executing `npm build` or `yarn build`.
2. Press `Ctrl + Shift + P` in Windows/Linux or `Shift ⇧ + Command ⌘ + P` in Mac and type/select `Azure App Service: Create New Web App...` to create a new web app.
   - Select your subscription
   - Enter your web app name
   - Select Linux as your OS
   - Select .Net Core Latest runtime
3. Once the creation is done, click "Deploy" in the notification window on the lower right corner.
   - Click "Browse" on the top middle section of your screen and select the publish folder within your project
   - Click "Yes" in the notification window on the lower right corner (build prompt)
   - Click "Deploy" on the window pop up
   - Click "Yes" in the notification window on the lower right corner again
4. Once the deployment is done, click "Browse website" in the notification window on the lower right corner to check out your newly deployed app.

Consider adding authentication and securing back-end API's by following [Azure App Service Security](https://docs.microsoft.com/en-us/azure/app-service/overview-security).

Full documentation for deployment to Azure App Service can be found here: [Deployment Docs](https://github.com/Microsoft/WebTemplateStudio/blob/dev/docs/deployment.md).

## File Structure

The front-end is based on [Angular cli "ng"](https://angular.io/cli).

The back-end is based on [ASP.NET Web API](https://dotnet.microsoft.com/apps/aspnet/apis).

The front-end is served on http://localhost:3000/ and the back-end on https://localhost:5001/.

```
.
├── server/ - ASP.NET Web Api that provides API routes and serves front-end
│ ├── Contracts/ - Interfaces for services
│ ├── Controllers/ - Handles API calls for routes
│ ├── Models/ - Data models
│ ├── Services/ - Data services
│ ├── appsettings.json - Configuration data file
│ ├── Program.cs - Contains create host and run application
│ ├── Startup.cs - Register services and configure application
│ └── WebApi.csproj - Configures Port and HTTP Server
├── src - Angular front-end
│ └── app - Angular main root module
│    ├── app-shell - Angular main components
│    └── app.module.ts - Angular root module.
└── README.md
```

## Additional Documentation

- Angular Docs - https://angular.io/docs
- Angular Router - https://angular.io/guide/router

- Bootstrap CSS - https://getbootstrap.com/
- .NET - https://dotnet.microsoft.com/
- ASP.NET - https://dotnet.microsoft.com/apps/aspnet


  This project was created using [Microsoft Web Template Studio](https://github.com/Microsoft/WebTemplateStudio).
