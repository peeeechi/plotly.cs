using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{
    public interface ITrace: IJavaScriptObject
    {
        ITraceData X {set;}
        ITraceData Y {set;}
        string Name {get; set;}
    }
}
