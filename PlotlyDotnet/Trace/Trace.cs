using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlotlyDotnet
{
    public class Trace<T> : ITraceData
    {
        protected IEnumerable<T> _data;

        protected bool IsValidType
        {
            get
            {
                Type selfType = typeof(T);
                return 
                    (
                    selfType == typeof(string)  ||
                    selfType == typeof(byte)    ||
                    selfType == typeof(sbyte)   ||
                    selfType == typeof(char)    ||
                    selfType == typeof(short)   ||
                    selfType == typeof(ushort)  ||
                    selfType == typeof(int)     ||
                    selfType == typeof(uint)    ||
                    selfType == typeof(long)    ||
                    selfType == typeof(ulong)   ||
                    selfType == typeof(decimal) ||
                    selfType == typeof(float)   ||
                    selfType == typeof(double)
                    );
            }
        }

        public Trace(IEnumerable<T> data)
        {
            if (!IsValidType)
            {
                throw new ArgumentException($"{typeof(T).Name} is not an accepted type");
            }
            this._data = data;
        }

        public string ToPlotString()
        {
            int count = this._data.Count();
            bool isString = typeof(T) == typeof(string);

            if (count == 0)
            {
                return "[]";
            }

            if (count == 1)
            {
                return isString? $"['{this._data.ElementAt(0)}']" : $"[{this._data.ElementAt(0)}]"; ;
            }


            StringBuilder sb = new StringBuilder();

            if (isString)
            {
                sb.Append($"['{this._data.ElementAt(0)}'");
                for (int i = 1; i < count; i++)
                {
                    sb.Append($",'{this._data.ElementAt(i)}'");
                }
                sb.Append("]");
            }
            else
            {
                sb.Append($"[{this._data.ElementAt(0)}");
                for (int i = 1; i < count; i++)
                {
                    sb.Append($",{this._data.ElementAt(i)}");
                }
                sb.Append("]");
            }

            return sb.ToString();
           
        }
    }
}
