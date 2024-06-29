using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class CASH
{
    public static Object[] ConvertListStringWrappedInArray(Object[] innerMain)
    {
        if (CASE.IsListStringWrappedInArray(innerMain))
        {
            List<object> result = null;
            var first = (IEnumerable)innerMain[0];
            if (first is List<object>)
            {
                result = (List<object>)first;
            }
            else
            {
                result = new List<object>();
                foreach (var item in first)
                {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }
        return innerMain;
    }

    public static bool IsListStringWrappedInArray<T>(List<T> v2)
    {
        var first = v2.First().ToString();
        if (v2.Count == 1 && (first == "System.Collections.Generic.List`1[System.String]" ||
        first == "System.Collections.Generic.List`1[System.Object]")) return true;
        return false;
    }
}

