using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace PlotlyDotnet
{
    public static class Plotly
    {
        static Encoding enc = new UTF8Encoding(false);
        public class PlotlyViewModel
        {
            public string IdString { get; set; }
            public string PlotlyLib { get; set; }
            public string DataArrayString { get; set; }
            public string LayoutString { get; set; }
            public string ConfigString { get; set; }
        }

        public static void NewPlot(IEnumerable<ITrace> data, Layout layout = null, Config config = null, string fileName = null)
        {
            int dataCount = data.Count();
            string dataString;
            if(dataCount == 0)          dataString = "[]";
            else if (dataCount <= 1)    dataString = $"[{data.ElementAt(0).ToJavaScriptObjStr()}]";
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"[{data.ElementAt(0).ToJavaScriptObjStr()}");
                for (int i = 1; i < dataCount; i++)
                    sb.Append($",{data.ElementAt(i).ToJavaScriptObjStr()}");

                sb.Append("]");
                dataString = sb.ToString();
            }

            // var plotlyLibString = new StreamReader("PlotlyDotnet/assets/plotly-v1.54.7.js").ReadToEnd();
            var plotlyLibString = enc.GetString(Assets.PlotlyLibBin);

            var vm = new PlotlyViewModel
            {
                IdString        = "plotly-cs-plot-area",
                PlotlyLib       = plotlyLibString,
                DataArrayString = dataString,
                LayoutString    = (layout is null)? "{}" : layout.ToJavaScriptObjStr(),
                ConfigString    = (config is null)? "{}" : config.ToJavaScriptObjStr(),
            };

            DotLiquidFunctions.RegisterViewModel(typeof(PlotlyViewModel));

            // var temp = new StreamReader("PlotlyDotnet/index.html").ReadToEnd();
            var temp = enc.GetString(Assets.TempBin);
            var template = DotLiquid.Template.Parse(temp);

            var result = template.RenderViewModel(vm);

            if (fileName is null)
            {
                fileName = Path.Combine(Directory.GetCurrentDirectory(), "plotly-cs-result.html");
            }
            else
            {
                string dir = Path.GetDirectoryName(fileName);
                if(!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            }

            using (var sw = new StreamWriter(fileName, false, enc))
            {
                sw.Write(result);
            }

            // System.Diagnostics.Process.Start(fileName);
        }
    }
}
