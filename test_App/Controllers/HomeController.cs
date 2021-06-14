using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using test_App.Models;

namespace test_App.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult linechart()
        {
            // string data_array = "[{'x':1, 'y':20},{'x':2,'y':33},{'x':3, 'y':42},{'x':4,'y':52}]";
            // Transfer datafrom controller to View.
            var point = GenerateLineSeries(1, 50);
            string data_array = JsonConvert.SerializeObject(point);          
            ViewData["DataPoints"] = data_array;
            return View();
        }

        public ActionResult threedchart()
        {
            // setting number of series and points to be generated in each series.
            var point = GeneratePointSeries(6, 10);
            string output = JsonConvert.SerializeObject(point);
            ViewData["DataPoints"] = output;
            return View();
        }
        // Generates a random collection of point series of points.
        // <param name="seriesCount">The number of point series to be generated.</param>
        // <param name="pointsPerSeries">The number of points to be genereated per point series.</param>
        // <returns>A collection of point series.</returns>
        private List<DataPoint[]> GeneratePointSeries(int seriesCount, int pointsPerSeries)
        {
            Random r = new Random();
            List<DataPoint[]> pointSeries = new List<DataPoint[]>();

            for (int i = 0; i < seriesCount; i++)
            {
                DataPoint[] points = new DataPoint[pointsPerSeries];
                for (int j = 0; j < pointsPerSeries; j++)
                {
                    points[j] = new DataPoint(j, r.Next(0, 100), r.Next(0, 100));
                }
                pointSeries.Add(points);
            }
            return pointSeries;
        }
        private List<linedata[]> GenerateLineSeries(int seriesCount, int pointsPerSeries)
        {
            Random r = new Random();
            List<linedata[]> lineSeries = new List<linedata[]>();

            for (int i = 0; i < seriesCount; i++)
            {
                linedata[] points = new linedata[pointsPerSeries];
                for (int j = 0; j < pointsPerSeries; j++)
                {
                    points[j] = new linedata(j, r.Next(10,100));
                }
                lineSeries.Add(points);
            }
            return lineSeries;
        }
    }
}