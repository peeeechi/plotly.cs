using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{
    public class Config: JavaScriptObjectBase
    {
        public bool? Responsive 
        { 
            get => (this._dataDict.ContainsKey(nameof(Config.Responsive).ToLower())? (bool?)this._dataDict[nameof(Config.Responsive).ToLower()]: null);
            set => this._dataDict[nameof(Config.Responsive).ToLower()] = value;
        }
    }
}
