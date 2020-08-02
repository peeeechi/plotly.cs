using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlotlyDotnet
{
    public class TraceData<T> : ITraceData
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

        public TraceData(IEnumerable<T> data)
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

    public static class TraceData
    {
        public static TraceData<byte> CreateFromEnumerator(IEnumerable<byte> data) { return new TraceData<byte>(data); }
        public static TraceData<sbyte> CreateFromEnumerator(IEnumerable<sbyte> data) { return new TraceData<sbyte>(data); }
        public static TraceData<Int16> CreateFromEnumerator(IEnumerable<Int16> data) { return new TraceData<Int16>(data); }
        public static TraceData<UInt16> CreateFromEnumerator(IEnumerable<UInt16> data) { return new TraceData<UInt16>(data); }
        public static TraceData<Int32> CreateFromEnumerator(IEnumerable<Int32> data) { return new TraceData<Int32>(data); }
        public static TraceData<UInt32> CreateFromEnumerator(IEnumerable<UInt32> data) { return new TraceData<UInt32>(data); }
        public static TraceData<Int64> CreateFromEnumerator(IEnumerable<Int64> data) { return new TraceData<Int64>(data); }
        public static TraceData<UInt64> CreateFromEnumerator(IEnumerable<UInt64> data) { return new TraceData<UInt64>(data); }
        public static TraceData<decimal> CreateFromEnumerator(IEnumerable<decimal> data) { return new TraceData<decimal>(data); }
        public static TraceData<float> CreateFromEnumerator(IEnumerable<float> data) { return new TraceData<float>(data); }
        public static TraceData<double> CreateFromEnumerator(IEnumerable<double> data) { return new TraceData<double>(data); }
        public static TraceData<string> CreateFromEnumerator(IEnumerable<string> data) { return new TraceData<string>(data); }
    }
}
