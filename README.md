# Using LightningChart<sup>&#174; </sup> JS with [ASP.Net MVC][0]
This repository showcases the usage of LightningChart<sup>&#174;</sup> JS charting tools within a ASP.Net web application.

More information about LightningChart<sup>&#174;</sup> JS can be found from our website, https://www.arction.com/lightningchart-js/

## Getting Started
This project can be opened with code editor like Visual Studio using the supplied solution file.For further details and download links, please refer to the Get Started guide for ASP.Net MVC [here][1]!


## Sending Data from MVC to LightningChart<sup>&#174; </sup> JS

In order to send data to LightningChart<sup>&#174; </sup> JS , using MVC framework the controller handles and responds to user input and interaction which retrieves data from model for line series(2D chart) and 3D chart. Using ViewData , data will be transfers from Controller to View.
For chart 2D
```
 string data_array = "[{'x':1, 'y':20},{'x':2,'y':33},{'x':3, 'y':42},{'x':4,'y':52}]";
 					or
			 var point = GenerateLineSeries(1, 50);	 
            // Transfer data from controller to View.
            ViewData["DataPoints"] = data_array;
            return View();
```

For chart 3D
``` 
 // setting number of series and points to be generated in each series.
            var point = GeneratePointSeries(6, 10);
           
 // Transfer data from controller to View.
            ViewData["DataPoints"] = point;
            return View();
```


## Support
If you notice an error in the example code, please open an issue on [GitHub][2].
Official [API documentation][3] can be found on [Arction][4] website.
If the docs and other materials do not solve your problem as well as implementation help is needed, ask on [StackOverflow][5] (tagged lightningchart).
If you think you found a bug in the LightningChart JavaScript library, please contact support@arction.com.
Direct developer email support can be purchased through a [Support Plan][6] or by contacting sales@arction.com.

© Arction Ltd 2009-2021. All rights reserved.

[0]: https://dotnet.microsoft.com/apps/aspnet/mvc
[1]: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started
[]:  https://visualstudio.microsoft.com/
[2]: https://github.com/Arction/lcjs-html-example/issues
[3]: https://www.arction.com/lightningchart-js-api-documentations
[4]: https://www.arction.com
[5]: https://stackoverflow.com/questions/tagged/lightningchart
[6]: https://www.arction.com/support-services/
