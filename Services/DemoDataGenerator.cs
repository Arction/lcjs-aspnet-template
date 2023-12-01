using LCJS_x_ASP.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace LCJS_x_ASP.Services
{
    public class DemoDataGenerator : BackgroundService
    {
        private readonly IHubContext<ChartHub> _hub;
        private readonly Random _random;
        private double _prevMeasurement;

        public DemoDataGenerator(IHubContext<ChartHub> hub)
        {
            _hub = hub;
            _random = new Random();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Stream real-time data to chart over life-time of demo application.
            while (!stoppingToken.IsCancellationRequested)
            {
                // Current time as UTC timestamp (commonly used in JavaScript)
                double timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                double measurement = _prevMeasurement + (_random.NextDouble() * 2.0 - 1.0);
                _prevMeasurement = measurement;

                DataPointXY[] dataPointArr = new DataPointXY[] { new DataPointXY(timestamp, measurement) };

                await _hub.Clients.All.SendAsync(
                    "add",
                    dataPointArr,
                    cancellationToken: stoppingToken
                );

                await Task.Delay(TimeSpan.FromMilliseconds(1), stoppingToken);
            }
        }
    }

    public struct DataPointXY
    {
        public double X { get; set; }
        public double Y { get; set; }
        public DataPointXY(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

}
