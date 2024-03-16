
using SunamoSerializer._sunamo;

namespace SunamoSerializer;
public partial class SF
{
    private static SerializeContentArgs s_contentArgs = new SerializeContentArgs();
    //CASH
    public static List<string> ParseUpToRequiredElementsLine(string input, int requiredCount)
    {
        var p = SF.GetAllElementsLine(input);
        if (p.Count > requiredCount)
        {
            throw new Exception($"p have {p.Count} elements, max is {requiredCount}");
        }
        else if (p.Count < requiredCount)
        {
            for (int i = p.Count - 1; i < requiredCount; i++)
            {
                p.Add(string.Empty);
            }
        }

        return p;
    }

    static Tuple<string, string, string> t => Exc.GetStackTrace2(true);

    public static Dictionary<T1, T2> ToDictionary<T1, T2>(List<List<string>> l)
    {
        object s1 = BTS.MethodForParse<T1>();
        object s2 = BTS.MethodForParse<T2>();

        Func<string, T1> p1 = (Func<string, T1>)s1;
        Func<string, T2> p2 = (Func<string, T2>)s2;

        Dictionary<T1, T2> dict = new Dictionary<T1, T2>();

        T1 t1 = default(T1);
        T2 t2 = default(T2);

        Dictionary<int, List<string>> whereIsNotTwoEls = new Dictionary<int, List<string>>();

        int i = -1;

        foreach (List<string> item in l)
        {
            i++;

            if (item.Count != 2)
            {
                whereIsNotTwoEls.Add(i, item);
                continue;
            }

            t1 = p1.Invoke(item[0]);
            t2 = p2.Invoke(item[1]);
            dict.Add(t1, t2);
        }

        foreach (var item in whereIsNotTwoEls)
        {
            var l2 = item.Value.ToList();
            l2.Insert(0, item.Key.ToString());
            //DebugLogger.Instance.WriteListOneRow(l2, AllStrings.swd);
        }

        if (whereIsNotTwoEls.Count != 0)
        {

        }

        return dict;
    }

    public static string separatorString
    {
        get
        {
            return s_contentArgs.separatorString;
        }

        set
        {
            s_contentArgs.separatorString = value;
        }
    }

    /// <summary>
    /// Without last |
    /// </summary>
    /// <param name="o"></param>
    /// <param name="p1"></param>
    /// <returns></returns>
    public static string PrepareToSerializationExplicitString(IList o, string p1 = AllStrings.verbar)
    {
        //var o3 = new List<string>(o);
        //var o2 = CA.Trim(o3);
        string vr = string.Join(p1, o);
        return vr;
        //return vr.Substring(0, vr.Length - p1.Length);
    }

    /// <summary>
    /// Without last |
    /// If need to combine string and IList, lets use CA.Join
    /// DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="o"></param>
    public static string PrepareToSerializationExplicit(IList o, string p1 = AllStrings.verbar)
    {

        return PrepareToSerializationExplicitString(o, p1.ToString());
    }

    /// <summary>
    /// In inner array is elements, in outer lines.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static List<List<string>> GetAllElementsFile(string file)
    {
        string firstLine = null;
        return GetAllElementsFile(file, ref firstLine);
    }


    public static List<string> RemoveComments(List<string> tf)
    {
        //CASH.RemoveStringsEmpty2(tf);

        tf = tf.Where(d => !string.IsNullOrWhiteSpace(d)).ToList();

        // Nevím vůbec co toto má znamenat ael nedává mi to smysl
        // Příště dopsat komentář pokud budu odkomentovávat
        //if (tf.Count > 0)
        //{
        //    if (tf[0].StartsWith(AllStrings.num))
        //    {
        //        return tf[0];
        //    }
        //}


        //CASH.RemoveStartingWith(AllStrings.num, tf);

        tf = tf.Where(d => !d.StartsWith(AllStrings.num)).ToList();
        return tf;

    }

    public static List<List<string>> GetAllElementsFile(string file, ref string firstCommentLine, string oddelovaciZnak = AllStrings.verbar)
    {

        var (header, rows) = GetAllElementsFileAdvanced(file, oddelovaciZnak);
        if (header.Count > 0)
        {
            rows.Insert(0, header);
        }

        return rows;
    }

    public static
#if ASYNC
    async Task
#else
    void
#endif
 Dictionary<T1, T2>(string file, Dictionary<T1, T2> artists)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in artists)
        {
            sb.AppendLine(PrepareToSerialization(item.Key.ToString(), item.Value.ToString()));
        }


#if ASYNC
        await
#endif
        File.WriteAllTextAsync(file, sb.ToString());
    }

    public static void WriteAllElementsToFile<Key, Value>(string coolPeopleShortcuts, Dictionary<Key, Value> d2)
    {
        List<List<string>> list = ListFromDictionary(d2);
        WriteAllElementsToFile(coolPeopleShortcuts, list);
    }

    public static async Task WriteAllElementsToFile(string VybranySouborLogu, List<List<string>> p)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in p)
        {
            sb.AppendLine(PrepareToSerialization2(item));
        }

        await File.WriteAllTextAsync(VybranySouborLogu, sb.ToString());
    }

    public static List<List<string>> ListFromDictionary<Key, Value>(Dictionary<Key, Value> d2)
    {
        List<List<string>> vs = new List<List<string>>();
        foreach (var item in d2)
        {
            vs.Add([item.Key.ToString(), item.Value.ToString()]);
        }
        return vs;
    }

    /// <summary>
    /// Without last |
    /// DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="o"></param>
    /// <param name="separator"></param>
    public static string PrepareToSerialization2(IList<string> o)
    {
        return PrepareToSerializationWorker(o, true, dDeli);
    }



    ///// <summary>
    ///// Return without last
    ///// DateTime is serialize always in english format
    ///// Opposite method: DTHelperEn.ToString<>DTHelperEn.ParseDateTimeUSA
    ///// </summary>
    ///// <param name="pr"></param>
    //public static string PrepareToSerialization2(params string[] pr)
    //{
    //    var ts = new List<string>(pr);
    //    return PrepareToSerializationWorker(ts, true, separatorString);
    //}

    /// <summary>
    /// Return without last
    /// If need to combine string and IList, lets use CA.Join
    /// </summary>
    /// <param name = "o"></param>
    public static string PrepareToSerializationExplicit2(IList<string> o, string separator = AllStrings.verbar)
    {
        return PrepareToSerializationWorker(o, true, separator);
    }

    public static
#if ASYNC
    async Task
#else
    void
#endif
 DictionaryAppend(string v, Dictionary<int, string> toSave)
    {
        var c = await File.ReadAllTextAsync(v);
        var s = ListFromDictionary<int, string>(toSave);
        var s2 = ToDictionary<int, string>(s);

        StringBuilder sb = new StringBuilder();
        foreach (var item in s2)
        {
            sb.AppendLine(SF.PrepareToSerialization(item.Key.ToString(), item.Value));
        }

#if ASYNC
        await
#endif
        File.AppendAllTextAsync(v, sb.ToString() + Environment.NewLine);
    }
}
