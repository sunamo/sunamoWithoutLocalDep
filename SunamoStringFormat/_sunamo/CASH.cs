
using System.Collections;

namespace SunamoStringFormat;

public class CASH
{
    public static Object[] ConvertListStringWrappedInArray(Object[] innerMain)
    {
        if (CASE.IsListStringWrappedInArray(innerMain.ToList()))
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
}
