namespace SunamoCollectionsShared;

using SunamoAttributes;
using SunamoCollectionsShared.Args;
using SunamoExceptions.InSunamoIsDerivedFrom;
using SunamoValues;
using System.Collections;
using System.Text.RegularExpressions;

public class CASH : CASE
{
    public static List<string> WrapWithIfFunc(Func<string, string, bool, bool> f, bool invert, string mustContains, string wrapWith, params string[] whereIsUsed2)
    {
        for (int i = 0; i < whereIsUsed2.Length; i++)
        {
            if (f.Invoke(whereIsUsed2[i], mustContains, invert))
            {
                whereIsUsed2[i] = wrapWith + whereIsUsed2[i] + wrapWith;
            }
        }
        return whereIsUsed2.ToList();
    }

    /// <summary>
    /// Return null if A1 will be null
    /// </summary>
    /// <param name="captions"></param>
    /// <param name="i"></param>
    public static object GetIndex(List<string> captions, int i)
    {
        if (captions == null)
        {
            return null;
        }
        if (!CASH.HasIndex(i, captions))
        {
            return null;
        }
        return captions[i];
    }

    /// <summary>
    /// ToListString2 - simply for all items call ToString()
    /// ToListString - working with type of every element
    /// 
    ///     Just 3 cases of working:
    ///     IList
    ///     <char>
    ///         => string
    ///         IList
    ///         <string>
    ///             => List
    ///             <string>
    ///                 IList => List<string>
    /// </summary>
    /// <param name="enumerable"></param>
    [ObjectParamsObsoleteAttribute]
    public static List<string> ToListStringIList(IList enumerable2)
    {
        return null;
        //List<string> result = new List<string>();
        //if (enumerable2.GetType() != typeof(string))
        //{
        //    foreach (object item in enumerable2)
        //    {
        //        Type t = item.GetType();
        //        // !(item is string)  - not working
        //        if (RHSE.IsOrIsDeriveFromBaseClass(t, Types.tIEnumerable))
        //        {
        //            // zde to musí být IEnumerable protože spousta věcí z .netu může takhle přijít (např. string)
        //            var enumerable = (System.Collections.IEnumerable)item;
        //            Type type = enumerable.GetType();

        //            bool isEnumerableChar = RHSE.IsOrIsDeriveFromBaseClass(type, typeof(IList<char>));
        //            bool isEnumerableString = RHSE.IsOrIsDeriveFromBaseClass(type, typeof(IList<string>));

        //            if (type == typeof(string))
        //            {


        //                result.Add(string.Join(string.Empty, enumerable));
        //            }
        //            else if (isEnumerableChar)
        //            {
        //                // IList<char> => string
        //                //enumerable2 is not string, then I can add all to list
        //                result.AddRange(ToListStringIEnumerable2(enumerable));
        //            }
        //            else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList<string>)
        //            {
        //                // IList<string> => List<string>
        //                result.AddRange(((IList<string>)enumerable.FirstOrNull()).ToList());
        //            }
        //            else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList &&
        //                     !isEnumerableChar && !isEnumerableString)
        //            {
        //                result.AddRange(ToListStringIEnumerable2((IList)enumerable.FirstOrNull()));
        //            }
        //            else
        //            {
        //                // IList => List<string>
        //                result.AddRange(ToListStringIEnumerable2(enumerable));
        //            }
        //        }
        //        else
        //        {
        //            result.Add(item.ToString());
        //        }
        //    }
        //}
        //else
        //{
        //    result.Add(enumerable2.ToString());
        //}

        //return result;
    }

    public static bool HasIndex(int dex, Array col)
    {
        return col.Length > dex;
    }
    public static bool HasIndex(int p, IList nahledy)
    {
        if (p < 0)
        {
            throw new Exception("Chybn\u00FD parametr p");
        }
        if (nahledy.Count > p)
        {
            return true;
        }
        return false;
    }

    public static string DoubleOrMoreMultiLinesToSingle(string list)
    {
        DoubleOrMoreMultiLinesToSingle(ref list);
        return list;
    }

    /// <summary>
    /// Return true if A1 is null or have zero elements
    /// </summary>
    /// <param name="mustBe"></param>
    public static bool IsEmptyOrNull(IList mustBe)
    {
        if (mustBe == null)
        {
            return true;
        }
        else if (mustBe.Count == 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Pro vyssi vykon uklada primo do zdrojoveho pole, pokud neni A2
    /// </summary>
    /// <param name="ss"></param>
    public static List<string> ToLower(List<string> ss, bool createNewArray = false)
    {
        List<string> outArr = ss;

        if (createNewArray)
        {
            outArr = new List<string>(ss.Count);
            CASE.InitFillWith(outArr, ss.Count);
        }

        for (int i = 0; i < ss.Count; i++)
        {
            outArr[i] = ss[i].ToLower();
        }
        return outArr;
    }

    public static void DoubleOrMoreMultiLinesToSingle(ref string list)
    {
        var n = Environment.NewLine;
        list = Regex.Replace(list, @"(\r?\n\s*){2,}", Environment.NewLine + Environment.NewLine);
        list = list.Trim();
        //list = list.Replace(n, n + n);

        // 27-10-23 dříve to bylo takhle
        //return list.Trim();
    }

    /// <summary>
    /// A1 musí být string[], kdyby byl string[] nemůžu vložit List<string>, tj. object ale ne string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="innerMain"></param>
    /// <returns></returns>
    [ObjectParamsObsolete]
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

    public static (bool, string) IsNegationTuple(string contains)
    {
        if (contains[0] == '!')
        {
            contains = contains.Substring(1);
            return (true, contains);
        }
        return (false, contains);
    }

    /// <summary>
    /// Remove elements starting with A1
    /// Direct edit
    /// </summary>
    /// <param name="start"></param>
    /// <param name="mySites"></param>
    public static void RemoveStartingWith(string start, List<string> mySites, RemoveStartingWithArgs a = null)
    {
        if (a == null)
        {
            a = new RemoveStartingWithArgs();
        }

        var (negate, start2) = IsNegationTuple(start);
        start = start2;

        for (int i = mySites.Count - 1; i >= 0; i--)
        {
            var val = mySites[i];
            if (a._trimBeforeFinding)
            {
                val = val.Trim();
            }

            if (negate)
            {
                if (!StartingWith(val, start, a.caseSensitive))
                {
                    mySites.RemoveAt(i);
                }
            }
            else
            {
                if (StartingWith(val, start, a.caseSensitive))
                {
                    mySites.RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    /// Direct edit
    /// </summary>
    /// <param name="v"></param>
    /// <param name="l"></param>
    /// <returns></returns>
    public static List<string> StartingWith(string v, List<string> l)
    {
        for (int i = l.Count - 1; i >= 0; i--)
        {
            if (!l[i].StartsWith(v))
            {
                l.RemoveAt(i);
            }
        }
        return l;
    }

    public static bool StartingWith(string val, string start, bool caseSensitive)
    {
        if (caseSensitive)
        {
            return val.StartsWith(start);
        }
        else
        {
            return val.ToLower().StartsWith(start.ToLower());
        }
    }

    public static List<string> RemoveStringsEmpty2(List<string> mySites)
    {
        for (int i = mySites.Count - 1; i >= 0; i--)
        {
            if (mySites[i].Trim() == string.Empty)
            {
                mySites.RemoveAt(i);
            }
        }
        return mySites;
    }
    static string Replace(string s, string from, string to)
    {
        return s.Replace(from, to);
    }

    /// <summary>
    /// Direct edit
    /// </summary>
    /// <param name="files_in"></param>
    /// <param name="what"></param>
    /// <param name="forWhat"></param>
    public static void Replace(List<string> files_in, string what, string forWhat)
    {
        for (int i = 0; i < files_in.Count; i++)
        {
            files_in[i] = Replace(files_in[i], what, forWhat);
        }
        //CAChangeContent.ChangeContent2(null, files_in, Replace, what, forWhat);
    }

    /// <summary>
    /// ToListString2 - simply for all items call ToString()
    /// ToListString - working with type of every element    
    /// 
    ///     <string>
    ///         Nothing more, nothing less
    ///         Must be private - to use only public in CA
    ///         bcoz Cast() not working
    ///         Dont make any type checking - could be done before
    /// </summary>
    public static List<string> ToListStringIEnumerable2(IEnumerable enumerable)
    {
        List<string> result = new List<string>(/*enumerable.Count()*/);
        foreach (object item in enumerable)
        {
            if (item == null)
            {
                result.Add(Consts.nulled);
            }
            else
            {
                result.Add(item.ToString());
            }
        }

        return result;
    }
}
