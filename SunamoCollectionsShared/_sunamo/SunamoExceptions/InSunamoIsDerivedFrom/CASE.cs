namespace SunamoCollectionsShared;


public class CASE
{
    public static void InitFillWith(List<string> datas, int pocet, string initWith = Consts.stringEmpty)
    {
        InitFillWith<string>(datas, pocet, initWith);
    }
    public static void InitFillWith<T>(List<T> datas, int pocet, T initWith)
    {
        for (int i = 0; i < pocet; i++)
        {
            datas.Add(initWith);
        }
    }
    public static void InitFillWith<T>(List<T> arr, int columns)
    {
        for (int i = 0; i < columns; i++)
        {
            arr.Add(default);
        }
    }
    /// <summary>
    ///     Usage: IEnumerableExtensions
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public static int Count(IEnumerable e)
    {
        if (e == null) return 0;
        var t = e.GetType();
        var tName = t.Name;
        // nevím jak to má .net core, zatím tu ThreadHelper nebudu přesouvat
        // if (ThreadHelper.NeedDispatcher(tName))
        // {
        //     int result = dCountSunExc(e);
        //     return result;
        // }
        if (e is IList) return (e as IList).Count;
        if (e is Array) return (e as Array).Length;
        var count = 0;
        foreach (var item in e) count++;
        return count;
    }
    /// <summary>
    ///     Direct edit input collection
    /// </summary>
    /// <param name="l"></param>
    public static List<string> Trim(List<string> l)
    {
        for (var i = 0; i < l.Count; i++) l[i] = l[i].Trim();
        return l;
    }
    public static string First(IEnumerable v2)
    {
        foreach (var item in v2) return item.ToString();
        return null;
    }
    public static bool IsListStringWrappedInArray(IEnumerable v2)
    {
        var first = First(v2);
        if (Count(v2) == 1 && (first == "System.Collections.Generic.List`1[System.String]" ||
        first == "System.Collections.Generic.List`1[System.Object]")) return true;
        return false;
    }
}