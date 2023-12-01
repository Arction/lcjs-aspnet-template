// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/// <reference path="../lib/lcjs/dist/lcjs.iife.d.ts" />
const { lightningChart, AxisTickStrategies, AxisScrollStrategies, Themes } =
  lcjs;

const lc = lightningChart({
  // IMPORTANT: Put your license key here https://lightningchart.com/js-charts/#license-key
  license: undefined
});

// This script exposes a function (`realTimeLineChart`) that can be used to create a HTML component in ASP .NET Views.
// It connects to SignalR for real-time data input.
const realTimeLineChart = (opts) => {
  const { hubUrl, containerID } = opts;
  const dateOrigin = new Date();
  const dateOriginTime = dateOrigin.getTime();
  const container = document.getElementById(containerID);
  if (!container) {
    throw new Error(`realTimeLineChart container not found. Check containerID`);
  }
  const chart = lightningChart().ChartXY({ container, theme: Themes.light });

  const axisX = chart
    .getDefaultAxisX()
    .setTickStrategy(AxisTickStrategies.DateTime, (ticks) =>
      ticks.setDateOrigin(dateOrigin)
    )
    .setScrollStrategy(AxisScrollStrategies.progressive)
    .setInterval({ start: -60 * 1000, end: 0, stopAxisAfter: false });
  const lineSeries = chart.addLineSeries({
    dataPattern: { pattern: "ProgressiveX" },
  });

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
    // For sub hour zoom ranges, timestamps have to be shifted closer to 0 using "date origin" concept.
    lineSeries.add(
      newDataPoints.map((p) => ({ x: p.x - dateOriginTime, y: p.y }))
    );
  });
};
