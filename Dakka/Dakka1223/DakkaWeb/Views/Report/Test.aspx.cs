using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using DakkaData;
using DakkaData.Enums;

namespace DakkaWeb.Views.Report
{
    public partial class Test : ViewPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            List<WorkRecord.DTO> records = ViewData["Records"] as List<WorkRecord.DTO>;
            if (records == null || records.Count <= 0)
            {
                return;
            }

            MainChart.ChartAreas["MainChartArea"].AxisY.IsReversed = true;

            Series exceptionSeries = MainChart.Series.Add("Exception");
            Series okSeries = MainChart.Series.Add("OK");
            Series nullSeries = MainChart.Series.Add("Null");

            exceptionSeries.MarkerSize = 8;
            exceptionSeries.XValueType = ChartValueType.Date;
            exceptionSeries.YValueType = ChartValueType.Time;
            exceptionSeries.ChartType = SeriesChartType.Point;
            exceptionSeries.IsVisibleInLegend = true;
            exceptionSeries.MarkerStyle = MarkerStyle.Star5;
            exceptionSeries.MarkerColor = Color.Red;

            okSeries.MarkerSize = 8;
            okSeries.XValueType = ChartValueType.Date;
            okSeries.YValueType = ChartValueType.Time;
            okSeries.ChartType = SeriesChartType.Point;
            okSeries.IsVisibleInLegend = true;
            okSeries.MarkerStyle = MarkerStyle.Circle;
            okSeries.MarkerColor = Color.Green;

            nullSeries.MarkerSize = 8;
            nullSeries.XValueType = ChartValueType.Date;
            nullSeries.YValueType = ChartValueType.Time;
            nullSeries.ChartType = SeriesChartType.Point;
            nullSeries.IsVisibleInLegend = true;
            nullSeries.MarkerStyle = MarkerStyle.Triangle;
            nullSeries.MarkerColor = Color.Blue;

            foreach (WorkRecord.DTO record in records)
            {
                if (record.Status == StatusEnum.Exception.Name)
                {
                    exceptionSeries.Points.AddXY(DateTime.Parse(record.WorkPoint).Date, DateTime.Parse(record.WorkPoint));
                }
                else if (record.Status == StatusEnum.OK.Name)
                {
                    okSeries.Points.AddXY(DateTime.Parse(record.WorkPoint).Date, DateTime.Parse(record.WorkPoint));
                }
                else
                {
                    nullSeries.Points.AddXY(DateTime.Parse(record.WorkPoint).Date, DateTime.Parse(record.WorkPoint));
                }
                
                
            }



        }


    }
}
