using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{
    public class Layout: JavaScriptObjectBase
    {
        public string Title
        { 
            get => (this._dataDict.ContainsKey(nameof(Layout.Title).ToLower()))? this._dataDict[nameof(Layout.Title).ToLower()].ToString() : null ; 
            set => this._dataDict[nameof(Layout.Title).ToLower()] = value;
        }
    }
}
