using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{
    public interface ITrace<Tx,Ty>
    {
        IEnumerable<Tx> X {set;}
        IEnumerable<Ty> Y {set;}
        string Name {get; set;}
    }
}
