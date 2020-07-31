using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{
    public abstract class TraceBase<Tx,Ty>: JavaScriptObjectBase, ITrace<Tx,Ty>
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
        public IEnumerable<Tx> X { set =>  this._dataDict[nameof(TraceBase<Tx,Ty>.X).ToLower()] = new Trace<Tx>(value); }

        /// <summary>
        /// Y値 を設定します
        /// </summary>
        public IEnumerable<Ty> Y { set =>  this._dataDict[nameof(TraceBase<Tx,Ty>.Y).ToLower()] = new Trace<Ty>(value);  }

        /// <summary>
        /// Trace 名 を取得、設定します
        /// </summary>
        public string Name { get => (this._dataDict.ContainsKey(nameof(TraceBase<Tx,Ty>.Name).ToLower()))? this._dataDict[nameof(TraceBase<Tx,Ty>.Name).ToLower()].ToString() : null; set => this._dataDict[nameof(TraceBase<Tx,Ty>.Name).ToLower()] = value; }
    }
}
