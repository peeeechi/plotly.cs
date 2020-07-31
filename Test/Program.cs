using System;
using System.Collections.Generic;
using System.Linq;
using PlotlyDotnet;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "StringNameKit";

            var sc3 = Scatter3D.CreateBasicTrace(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 });

            Console.WriteLine(sc3.ToJavaScriptObjStr());

        }
    }
}
