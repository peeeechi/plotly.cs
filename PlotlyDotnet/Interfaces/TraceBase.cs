using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{
    public abstract class TraceBase: JavaScriptObjectBase, ITrace
    {
        public TraceBase()
        {
            this._dataDict["type"] = GetChartType();
        }

        /// <summary>
        /// Plotly のChartType返す関数を設定します
        /// </summary>
        /// <returns>ChartType(文字列) EX: scatter, scatter3d ...etc </returns>
        protected abstract string GetChartType();

        /// <summary>
        /// X値 を設定します
        /// </summary>
        public ITraceData X { set =>  this._dataDict[nameof(TraceBase.X).ToLower()] = value; }

        /// <summary>
        /// Y値 を設定します
        /// </summary>
        public ITraceData Y { set =>  this._dataDict[nameof(TraceBase.Y).ToLower()] = value;  }

        /// <summary>
        /// Trace 名 を取得、設定します
        /// </summary>
        public string Name { get => (this._dataDict.ContainsKey(nameof(TraceBase.Name).ToLower()))? this._dataDict[nameof(TraceBase.Name).ToLower()].ToString() : null; set => this._dataDict[nameof(TraceBase.Name).ToLower()] = value; }
    }
}
