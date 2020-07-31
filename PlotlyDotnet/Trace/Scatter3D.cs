using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{
    public class Scatter3D<Tx,Ty,Tz>: TraceBase<Tx,Ty>
    {
        protected override string GetChartType() => "scatter3d";

        public Scatter3D() : base() {}

        /// <summary>
        /// Z値 を設定します
        /// </summary>
        public IEnumerable<Tz> Z { set =>  this._dataDict[nameof(Scatter3D<Tx,Ty,Tz>.Z).ToLower()] = new Trace<Tz>(value); }
    }

    public static class Scatter3D
    {
        public static Scatter3D<Tx, Ty, Tz> CreateBasicTrace<Tx, Ty, Tz>(IEnumerable<Tx> x, IEnumerable<Ty> y, IEnumerable<Tz> z)
        {
            return new Scatter3D<Tx, Ty, Tz>()
            {
                X = x,
                Y = y,
                Z = z
            };
        }
    }
}
