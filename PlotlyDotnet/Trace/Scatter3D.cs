using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{
    public class Scatter3D: TraceBase
    {
        protected override string GetChartType() => "scatter3d";

        public Scatter3D() : base() {}

        /// <summary>
        /// Z値 を設定します
        /// </summary>
        public ITraceData Z { set =>  this._dataDict[nameof(Scatter3D.Z).ToLower()] = value; }
    }

    // public static class Scatter3D
    // {
    //     public static Scatter3D CreateBasicTrace(IEnumerable<object> x, IEnumerable<object> y, IEnumerable<object> z)
    //     {
    //         return new Scatter3D()
    //         {
    //             X = x,
    //             Y = y,
    //             Z = z
    //         };
    //     }
    // }
}
