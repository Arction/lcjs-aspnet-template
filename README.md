# LightningChart JS in ASP.NET Core Web App

This repository is a minimal example of using LightningChart JS in an ASP.NET Core Web App.
It produces a real-time scrolling time series, with data transfer from a demonstration data generator service to LCJS via a SignalR hub.

https://github.com/Arction/lcjs-aspnet-template/assets/55391673/3aea8e36-c265-4941-805e-3c323f2b0b1f

More information can be found at [LightningChart JS documentation](https://lightningchart.com/js-charts/docs/frameworks/asp-dot-net/)

## Running the template

1. Open the solution in Visual Studio
2. Install client-side dependencies by opening Solution Explorer, finding `libman.json`, right clicking on it and selecting "Restore Client-Side Libraries"
3. Place your LightningChart JS license key in `wwwroot/js/chart.js`
   - If you don't have one, you can get it from https://lightningchart.com/js-charts/#license-key
4. Press `Start` button in Visual Studio

## Creation of the template

The template was created using the ASP.NET Core Web App project template from Microsoft 12/2023, with .NET 6.0 framework.
LightningChart JS dependency was added using `libman.json` with following configuration to download the library from `jsdelivr.com`:

```json
{
  "version": "1.0",
  "defaultProvider": "cdnjs",
  "libraries": [
    {
      "library": "@lightningchart/lcjs@7.0.1",
      "destination": "wwwroot/lib/lcjs",
      "provider": "jsdelivr"
    }
  ]
}
```

All other changes, such as creating the example application, using LCJS library and using SignalR have been isolated into one convenient Git commit which you can view [HERE](https://github.com/Arction/lcjs-aspnet-template/commit/12f96656bbc01ef5c31b537798c91ed11131e754).
