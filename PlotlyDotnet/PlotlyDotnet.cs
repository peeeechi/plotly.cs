using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{

    public enum ChartType
    {
        scatter = 0,
        scatter3D,
        bar,
    }

    public static class PlotlyDotnet
    {
        private static Dictionary<ChartType, string> ChartTypeDict = new Dictionary<ChartType, string>
            {
                {ChartType.scatter, "scatter" },
            };


        public static void Plot()
        {

        }
    }
}
