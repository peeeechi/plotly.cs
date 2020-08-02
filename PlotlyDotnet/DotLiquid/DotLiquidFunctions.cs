using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DotLiquid;

namespace PlotlyDotnet
{
    public static class DotLiquidFunctions
    {
        private static void RegisterSafeType(Type type)
        {
            Template
            .RegisterSafeType(type, type.GetProperties()
            .Select(prop => prop.Name).ToArray());
        }

        public static void RegisterViewModel(Type type)
        {
            type.Assembly
            .GetTypes()
            .Where(t => t.Namespace == type.Namespace)
            .ToList()
            .ForEach(registType => DotLiquidFunctions.RegisterSafeType(registType));
        }

        public static string RenderViewModel(this Template temp, object vm)
        {
            return temp.Render(Hash.FromAnonymousObject(vm));
        }
    }
}
