using System;
using System.Collections.Generic;
using System.Linq;
using PlotlyDotnet;
using System.Reflection;
using System.Resources;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // ResourceManager rm = new ResourceManager("GreetingResources", typeof(Program).Assembly);
            // Console.Write(rm.GetString("prompt"));
            // string name = Console.ReadLine();
            // Console.WriteLine(rm.GetString("greeting"), name);


            // using (ResourceWriter rw = new ResourceWriter(@".\CarResources.resources"))
            // {
            //     rw.AddResource("Name", "Classic American Cars");
            // }

            // string name = "StringNameKit";

            // var sc3 = Scatter3D.CreateBasicTrace(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 });
            var sc3 = new Scatter3D{
                X = TraceData.CreateFromEnumerator(new int[] {1,2,3}),
                Y = TraceData.CreateFromEnumerator(new List<int> {1,2,3}),
                Z = TraceData.CreateFromEnumerator(new int[] {1,2,3}),
                };
            Console.WriteLine(sc3.ToJavaScriptObjStr());

            Plotly.NewPlot(new ITrace[]{sc3});
        }
    }
}
