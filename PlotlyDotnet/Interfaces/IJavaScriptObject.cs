using System;
using System.Collections.Generic;
using System.Text;

namespace PlotlyDotnet
{
    public interface IJavaScriptObject
    {
        string ToJavaScriptObjStr();
    }

    public abstract class JavaScriptObjectBase: IJavaScriptObject
    {
        /// <summary>
        /// 内部データ(JavaScript文字列へ変換するものは全てこのDictionaryへ格納すること)
        /// </summary>
        /// <typeparam name="string">Property Key Name(kebab-case)</typeparam>
        /// <typeparam name="object">Property Data</typeparam>
        protected Dictionary<string, object> _dataDict = new Dictionary<string, object>();

        /// <summary>
        /// JavaScript の Object(文字列)へ変換します
        /// </summary>
        /// <returns>JavaScript の Object(文字列)</returns>
        public string ToJavaScriptObjStr()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (var item in this._dataDict)
            {
                if (item.Value is IJavaScriptObject)
                {
                    sb.Append($"{item.Key}:{((IJavaScriptObject)(item.Value)).ToJavaScriptObjStr()},");
                }
                else if(item.Value is ITraceData)
                {
                    sb.Append($"{item.Key}:{((ITraceData)(item.Value)).ToPlotString()},");
                }
                else if (item.Value.GetType() == typeof(string))
                {
                    sb.Append($"{item.Key}:'{item.Value}',");
                }
                else
                {
                    sb.Append($"{item.Key}:{item.Value},");
                }
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}
