// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/// <reference path="../lib/lcjs/dist/lcjs.iife.d.ts" />
const {
  lightningChart,
  AxisTickStrategies,
  AxisScrollStrategies,
  Themes,
  emptyFill,
} = lcjs;

const lc = lightningChart({
  // IMPORTANT: Put your license key here https://lightningchart.com/js-charts/#license-key
  license: undefined,
});

// This script exposes a function (`realTimeLineChart`) that can be used to create a HTML component in ASP .NET Views.
// It connects to SignalR for real-time data input.
const realTimeLineChart = (opts) => {
  const { hubUrl, containerID } = opts;
  const container = document.getElementById(containerID);
  if (!container) {
    throw new Error(`realTimeLineChart container not found. Check containerID`);
  }
  const chart = lightningChart().ChartXY({
    container,
    theme: Themes.light,
    defaultAxisX: { type: "linear-highPrecision" },
  });

  const axisX = chart.axisX
    .setTickStrategy(AxisTickStrategies.DateTime)
    .setScrollStrategy(AxisScrollStrategies.progressive)
    .setInterval({ start: -60 * 1000, end: 0, stopAxisAfter: false });
  const lineSeries = chart
    .addPointLineAreaSeries({
      dataPattern: "ProgressiveX",
    })
    .setAreaFillStyle(emptyFill);

  const connection = new signalR.HubConnectionBuilder()
    .withUrl(hubUrl)
    .withAutomaticReconnect()
    .configureLogging(signalR.LogLevel.Information)
    .build();

  async function start() {
    try {
      await connection.start();
      console.log("SignalR Connected.");
    } catch (err) {
      console.log(err);
      setTimeout(start, 5000);
    }
  }
  start();

  connection.on("add", (newDataPoints) => {
    // dataPoint: { x: number, y: number }[]
    lineSeries.appendJSON(newDataPoints);
  });
};
