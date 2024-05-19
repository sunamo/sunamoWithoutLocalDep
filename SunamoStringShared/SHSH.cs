namespace
#if SunamoDevCode
SunamoDevCode
#else
SunamoStringShared
#endif
;




using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

//using SunamoValues;

public class SHSH
{
    public static string WhiteSpaceFromStart(string v)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in v)
        {
            if (char.IsWhiteSpace(item))
            {
                sb.Append(item);
            }
            else
            {
                break;
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// FixedSpace - Contains
    /// AnySpaces - split input by spaces and A1 must contains all parts
    /// ExactlyName - Is exactly the same
    ///
    ///
    /// </summary>
    /// <param name="input"></param>
    /// <param name="term"></param>
    /// <param name="enoughIsContainsAttribute"></param>
    /// <param name="caseSensitive"></param>
    public static bool ContainsBoolBool(string input, string term, bool enoughIsContainsAttribute, bool caseSensitive)
    {
        return Contains(input, term, enoughIsContainsAttribute ? SearchStrategy.AnySpaces : SearchStrategy.ExactlyName, caseSensitive);
    }

    /// <summary>
    /// AnySpaces - split A2 by spaces and A1 must contains all parts
    /// ExactlyName - ==
    /// FixedSpace - simple contains
    /// </summary>
    /// <param name="input"></param>
    /// <param name="term"></param>
    /// <param name="searchStrategy"></param>
    /// <param name="caseSensitive"></param>
    public static bool Contains(string input, string term, SearchStrategy searchStrategy, bool caseSensitive)
    {
        if (term != "")
        {
            if (searchStrategy == SearchStrategy.ExactlyName)
            {
                if (caseSensitive)
                {
                    return input == term;
                }
                else
                {
                    return input.ToLower() == term.ToLower();
                }
            }
            else
            {
                if (searchStrategy == SearchStrategy.FixedSpace)
                {
                    if (caseSensitive)
                    {
                        return input.Contains(term);
                    }
                    else
                    {
                        return input.ToLower().Contains(term.ToLower());
                    }
                }
                else
                {
                    if (caseSensitive)
                    {
                        var allWords = term.Split(new String[] { AllStrings.space }, StringSplitOptions.RemoveEmptyEntries).ToList();// SHSplit.Split(term, );
                        return ContainsAll(input, allWords);
                    }
                    else
                    {
                        var allWords = term.Split(new String[] { AllStrings.space }, StringSplitOptions.RemoveEmptyEntries).ToList();// SHSplit.Split(term, AllStrings.space);
                        for (int i = 0; i < allWords.Count; i++)
                        {
                            allWords[i] = allWords[i].ToLower();
                        }
                        return ContainsAll(input.ToLower(), allWords);
                    }
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Auto remove potentially first !
    /// </summary>
    /// <param name="item"></param>
    /// <param name="contains"></param>
    public static bool IsContained(string item, ref string contains)
    {
        var (negation, contains2) = IsNegationTuple(contains);
        contains = contains2;

        if (negation && item.Contains(contains))
        {
            return false;
        }
        else if (!negation && !item.Contains(contains))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Return whether A1 contains all from A2
    /// </summary>
    /// <param name="input"></param>
    /// <param name="allWords"></param>
    public static bool ContainsAll(string input, IList<string> allWords, ContainsCompareMethod ccm = ContainsCompareMethod.WholeInput)
    {
        if (ccm == ContainsCompareMethod.SplitToWords)
        {
            foreach (var item in allWords)
            {
                if (!input.Contains(item))
                {
                    return false;
                }
            }
        }
        else if (ccm == ContainsCompareMethod.Negations)
        {
            foreach (var item in allWords)
            {
                var c = item.ToString();
                if (!IsContained(input, ref c))
                {
                    return false;
                }
            }
        }
        else if (ccm == ContainsCompareMethod.WholeInput)
        {
            foreach (var item in allWords)
            {
                if (!input.Contains(item))
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// AnySpaces - split A2 by spaces and A1 must contains all parts
    /// ExactlyName - ==
    /// FixedSpace - simple contains
    ///
    /// A1 = search for exact occur. otherwise split both to words
    /// Control for string.Empty, because otherwise all results are true
    /// </summary>
    /// <param name="input"></param>
    /// <param name="what"></param>
    public static bool Contains(string input, string term, SearchStrategy searchStrategy = SearchStrategy.FixedSpace)
    {
        return Contains(input, term, searchStrategy, true);
    }

    public static string PrefixIfNotStartedWith(string item, string http, bool skipWhitespaces = false)
    {
        string whitespaces = string.Empty;

        if (skipWhitespaces)
        {
            whitespaces = WhiteSpaceFromStart(item);
            item = item.Substring(whitespaces.Length);
        }

        if (!item.StartsWith(http))
        {
            return whitespaces + http + item;
        }

        return whitespaces + item;
    }

    public static string RemoveLastChar(string artist)
    {
        return artist.Substring(0, artist.Length - 1);
    }

    /// <summary>
    /// Add postfix if text not ends with
    /// </summary>
    /// <param name="text"></param>
    /// <param name="postfix"></param>
    /// <returns></returns>
    public static string PostfixIfNotEmpty(string text, string postfix)
    {
        if (text.Length != 0)
        {
            if (!text.EndsWith(postfix))
            {
                return text + postfix;
            }
        }
        return text;
    }

    public static string AddBeforeUpperChars(string text, char add, bool preserveAcronyms)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;
        StringBuilder newText = new StringBuilder(text.Length * 2);
        newText.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]))
                if ((text[i - 1] != add && !char.IsUpper(text[i - 1])) ||
                (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                    newText.Append(add);
            newText.Append(text[i]);
        }
        return newText.ToString();
    }

    public static string RemoveEndingPairCharsWhenDontHaveStarting(string vr, string cbl, string cbr)
    {
        List<int> removeOnIndexes = new List<int>();

        var sb = new StringBuilder(vr);


        var occL = ReturnOccurencesOfString(vr, cbl);
        var occR = ReturnOccurencesOfString(vr, cbr);
        List<int> onlyLeft = null;
        List<int> onlyRight = null;


        var l = GetPairsStartAndEnd(occL, occR, ref onlyLeft, ref onlyRight);

        onlyLeft.AddRange(onlyRight);
        onlyLeft.Sort();

        for (int i = onlyLeft.Count - 1; i >= 0; i--)
        {
            sb.Remove(onlyLeft[i], 1);
        }

        //if (occL.Count == 0)
        //{
        //    result = vr.SHReplace.Replace(AllStrings.rcub, string.Empty);
        //}
        //else
        //{
        //

        //    int left = -1;
        //    int right = -1;

        //    var onlyLeft = new List<int>();

        //    var pairs = SH.GetPairsStartAndEnd(occL, occR, ref onlyLeft);

        //    while (true)
        //    {
        //        if (occR.Count == 0)
        //        {
        //            break;
        //        }

        //        if (occL.Count == 0)
        //        {
        //            break;
        //        }

        //        left = occL.First();
        //        right = occR.First();

        //        if (right > left)
        //        {
        //            removeOnIndexes.Add(right);
        //            occR.RemoveAt(0);
        //        }
        //        else
        //        {
        //            // right, remove from right
        //            occR.RemoveAt(0);
        //        }
        //    }

        //    StringBuilder sb = new StringBuilder(vr);

        //    for (int i = removeOnIndexes.Count - 1; i >= 0; i--)
        //    {
        //        vr.Remove(removeOnIndexes[i], 1);
        //    }

        //    result = vr.ToLower();
        //}

        return sb.ToString();
    }

    public static List<Tuple<int, int>> GetPairsStartAndEnd(List<int> occL, List<int> occR, ref List<int> onlyLeft, ref List<int> onlyRight)
    {
        var l = new List<Tuple<int, int>>();

        onlyLeft = occL.ToList();
        onlyRight = occR.ToList();

        for (int i = occR.Count - 1; i >= 0; i--)
        {
            int lastRight = occR[i];
            if (occL.Count == 0)
            {
                break;
            }
            var lastLeft = occL.Last();

            if (lastRight < lastLeft)
            {
                i++;
                // Na konci přebývá lastLeft

                // onlyLeft.Add(lastLeft);
                // I will remove it on end
                occL.RemoveAt(occL.Count - 1);
            }
            else
            {
                // když je lastLeft menší, znamená to že last right má svůj levý protějšek
                l.Add(new Tuple<int, int>(lastLeft, lastRight));
            }
        }

        occL = onlyLeft;

        //foreach (var item in l)
        //{
        //    occL.Remove(item.Item1);
        //}

        // occL = onlyLeft o pár řádků výše
        //onlyLeft.AddRange(occL);

        //l.Reverse();

        var addToAnotherCollection = new List<int>();
        var l2 = new List<Tuple<int, int>>();

        List<int> alreadyProcessedItem1 = new List<int>();
        for (int i = l.Count - 1; i >= 0; i--)
        {
            if (alreadyProcessedItem1.Contains(l[i].Item1))
            {
                addToAnotherCollection.Add(l[i].Item1);
                l2.Add(l[i]);
                l.RemoveAt(i);
                //continue;
            }


            alreadyProcessedItem1.Add(l[i].Item1);
        }

        //for (int i = l2.Count - 1; i >= 0; i--)
        //{
        //    if (l.Contains(l2[i]))
        //    {
        //        l2.RemoveAt(i);
        //    }
        //}
        addToAnotherCollection = addToAnotherCollection.Distinct().ToList();
        foreach (var item in addToAnotherCollection)
        {
            var count = alreadyProcessedItem1.Where(d => d == item).Count();
            //!alreadyProcessedItem1.Contains(item)

            if (count > 2)
            {


                var sele = l2.Where(d => d.Item1 == item).ToList();
                //for (int i = sele.Count() - 1; i >= 1; i--)
                //{
                //    l2.Remove(sele[i]);
                //}

                var dx2 = occL.IndexOf(sele[0].Item1);
                if (dx2 != -1)
                {
                    var dx3 = l.IndexOf(sele[0]);
                    l.Add(new Tuple<int, int>(occL[dx2 - 1], sele[0].Item2));
                }

            }
        }

        //l.AddRange(l2);

        occL.Sort();




        var result = l; //l.OrderByDescending(d => d.Item1).ToList();
                        //

        List<int> alreadyProcessed = new List<int>();

        int dx = -1;

        for (int y = 0; y < result.Count; y++)
        {
            var item = result[y];
            var i = item.Item1;

            if (alreadyProcessed.Contains(i))
            {
                dx = occL.IndexOf(i);
                if (dx != -1)
                {
                    i = occL[dx - 1];
                    result[i] = new Tuple<int, int>(i, result[y - 1].Item2);
                }
            }

            alreadyProcessed.Add(i);
        }



        onlyLeft = occL;

        onlyLeft = onlyLeft.Distinct().ToList();
        onlyRight = onlyRight.Distinct().ToList();

        foreach (var item in result)
        {
            onlyLeft.Remove(item.Item1);
            onlyRight.Remove(item.Item2);
        }

        result.Reverse();

        return result;
    }

    public static string RemoveAndInsertReplace(string s, int startIndex, string what, string to)
    {
        s = s.Remove(startIndex, what.Length);
        s = s.Insert(startIndex, to);
        return s;
    }

    public static string JoinMakeUpTo2NumbersToZero(string d, int[] d2)
    {
        return d;
    }


    public static string ReplaceOnce(string input, string what, string zaco)
    {

        if (what == "")
        {
            return input;
        }

        int pos = input.IndexOf(what);
        if (pos == -1)
        {
            return input;
        }
        return input.Substring(0, pos) + zaco + input.Substring(pos + what.Length);
    }

    public static string ReplaceOnceIfStartedWith(string what, string replaceWhat, string zaCo)
    {
        bool replaced;
        return ReplaceOnceIfStartedWith(what, replaceWhat, zaCo, out replaced);
    }
    public static string ReplaceOnceIfStartedWith(string what, string replaceWhat, string zaCo, out bool replaced)
    {
        replaced = false;
        if (what.StartsWith(replaceWhat))
        {
            replaced = true;
            return ReplaceOnce(what, replaceWhat, zaCo);
        }
        return what;
    }

    public static string NormalizeString(string s)
    {
        if (s.Contains(AllChars.nbsp))
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in s)
            {
                if (item == AllChars.nbsp)
                {
                    sb.Append(AllChars.space);
                }
                else
                {
                    sb.Append(item);
                }
            }
            return sb.ToString();
        }

        return s;
    }

    /// <summary>
    /// IndexesOfChars - char
    /// ReturnOccurencesOfString - string
    /// </summary>
    /// <param name="vcem"></param>
    /// <param name="co"></param>
    /// <returns></returns>
    public static List<int> ReturnOccurencesOfString(string vcem, string co)
    {
        vcem = NormalizeString(vcem);
        List<int> Results = new List<int>();
        for (int Index = 0; Index < (vcem.Length - co.Length) + 1; Index++)
        {
            var subs = vcem.Substring(Index, co.Length);
            ////////DebugLogger.Instance.WriteLine(subs);
            // non-breaking space. &nbsp; code 160
            // 32 space
            char ch = subs[0];
            char ch2 = co[0];
            if (subs == AllStrings.space)
            {
            }
            if (subs == co)
                Results.Add(Index);
        }
        return Results;
    }

    public static List<int> TabOrSpaceNextTo(string input)
    {
        var tabs = ReturnOccurencesOfString(input, AllStrings.tab);

        // nevím k čemu to tu je ale když jsem měl řetězec b nopCommerce\tSimplCommerce\tSmartStoreNET\tgrandnode\tKartris tak mi to vrátilo navíc o 2 \t kde nikdy nebyly

        //for (int i = 0; i < tabs.Count-1; i++)
        //{
        //    var dx = tabs[i] + 1;
        //    if (input[i] == AllChars.space)
        //    {
        //        tabs.Add(dx);
        //    }
        //}

        //for (int i = 1; i < tabs.Count; i++)
        //{
        //    var dx = tabs[i] - 1;
        //    if (input[i] == AllChars.space)
        //    {
        //        tabs.Add(dx);
        //    }
        //}
        return tabs;
    }
    public static string WrapWithBs(string commitMessage)
    {
        return WrapWithChar(commitMessage, AllChars.bs);
    }

    #region MyRegion
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string WrapWith(string value, string h)
    {
        return h + value + h;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string WrapWithChar(string value, char v, bool _trimWrapping = false, bool alsoIfIsWhitespaceOrEmpty = true)
    {
        if (string.IsNullOrWhiteSpace(value) && !alsoIfIsWhitespaceOrEmpty)
        {
            return string.Empty;
        }

        // TODO: Make with StringBuilder, because of WordAfter and so
        return WrapWith(_trimWrapping ? value.Trim() : value, v.ToString());
    }
    #endregion

    public static string WrapWithSpace(string originalLogin)
    {
        return WrapWithChar(originalLogin, AllChars.space);
    }

    public static string WrapWithQm(string commitMessage)
    {
        return WrapWithQm(commitMessage, true);
    }

    public static string WrapWithIf(string value, string v, Func<string, string, bool> f)
    {
        if (f.Invoke(value, v))
        {
            return WrapWith(value, v);
        }
        return value;
    }

    public static string WrapWithQm(string commitMessage, bool alsoIfIsWhitespaceOrEmpty = true)
    {
        return WrapWithChar(commitMessage, AllChars.qm, alsoIfIsWhitespaceOrEmpty);
    }



    public static int OccurencesOfStringIn(string source, string p_2)
    {
        return source.Split(new string[] { p_2 }, StringSplitOptions.None).Length - 1;
    }

    /// <summary>
    /// Into A1,2 never put null
    /// </summary>
    /// <param name="pred"></param>
    /// <param name="za"></param>
    /// <param name="text"></param>
    /// <param name="pozice"></param>
    public static void GetPartsByLocation(out string pred, out string za, string text, int pozice)
    {
        if (pozice == -1)
        {
            pred = text;
            za = "";
        }
        else
        {
            pred = text.Substring(0, pozice);
            if (text.Length > pozice + 1)
            {
                za = text.Substring(pozice + 1);
            }
            else
            {
                za = string.Empty;
            }
        }
    }

    public static (string, string) GetPartsByLocationNoOutInt(string text, int pozice)
    {
        string pred, za;
        GetPartsByLocation(out pred, out za, text, pozice);
        return (pred, za);
    }

    public static (string, string) GetPartsByLocationNoOut(string text, char or)
    {
        GetPartsByLocation(out var pred, out var za, text, or);
        return (pred, za);
    }

    /// <param name="pred"></param>
    /// <param name="za"></param>
    /// <param name="text"></param>
    /// <param name="or"></param>
    public static void GetPartsByLocation(out string pred, out string za, string text, char or)
    {
        int dex = text.IndexOf(or);
        GetPartsByLocation(out pred, out za, text, dex);
    }

    /// <summary>
    ///     Func<int, bool> / FromToList
    /// </summary>
    /// <param name="o"></param>
    /// <param name="nt"></param>
    /// <returns></returns>
    public static bool NotAllowedInRanges(object o, int nt)
    {
        if (o is Func<int, bool>)
        {
            var t = (Func<int, bool>)o;
            return t(nt);
        }

        // nemůže tu být protože SunamoData musí dědit od SunamoStringShared - hodně metod *. 
        //if (o is FromToList)
        //{
        //    var r = (FromToList)o;
        //    return r.IsInRange(nt);
        //}

        ThrowEx.NotImplementedCase("NotAllowedInRanges: " + o);
        return false;
    }



    /// <summary>
    ///     notAllowedInRanges can be Func
    ///     <int, bool>
    ///         (delegát který vrací zda daný index může být použít pro end) or FromToList
    ///         Used in: Metaproject.PackageIndex.Functions.ParseCsprojFile
    ///         Work like everybody excepts, from a {b} c return b
    ///         A5 is type FromToList but into SE could be only absolutely minimal code base
    /// </summary>
    /// <param name="p"></param>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    public static string GetTextBetweenTwoChars(string p, char beginS, char endS,
    bool throwExceptionIfNotContains = true, object notAllowedInRanges = null, bool endLastIndexOf = false)
    {
        var begin = p.IndexOf(beginS);
        var end = -1;
        if (endLastIndexOf)
        {
            end = p.LastIndexOf(endS);
        }
        else
        {
            end = p.IndexOf(endS, begin + 1);

            if (notAllowedInRanges != null)
                while (end != NumConsts.mOne && NotAllowedInRanges(notAllowedInRanges, end))
                    end = p.IndexOf(endS, end + 1);
        }

        if (begin == NumConsts.mOne || end == NumConsts.mOne)
        {
            if (throwExceptionIfNotContains)
            {
                ThrowEx.NotContains(p, beginS.ToString(), endS.ToString());
            }
            else
            {
                if (end == NumConsts.mOne) return null;
            }
        }
        else
        {
            return GetTextBetweenTwoCharsInts(p, begin, end);
        }

        return p;
    }

    public static string GetTextBetweenTwoCharsInts(string p, int begin, int end)
    {
        if (end > begin)
            // a(1) - 1,3
            return p.Substring(begin + 1, end - begin - 1);
        // originally
        //return p.Substring(begin+1, end - begin - 1);
        return p;
    }



    public static void FirstCharUpper(ref string nazevPP)
    {
        nazevPP = FirstCharUpper(nazevPP);
    }

    public static string FirstCharUpper(string nazevPP)
    {
        if (nazevPP.Length == 1)
        {
            return nazevPP.ToUpper();
        }

        string sb = nazevPP.Substring(1);
        return nazevPP[0].ToString().ToUpper() + sb;
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
    /// Musi mit sudy pocet prvku
    /// Pokud sudý [0], [2], ... bude mít aspoň jeden nebílý znak, pak se přidá lichý [1], [3] i sudý ve dvojicích. jinak nic
    /// </summary>
    /// <param name="className"></param>
    /// <param name="v1"></param>
    /// <param name="methodName"></param>
    /// <param name="v2"></param>
    public static string ConcatIfBeforeHasValue(params string[] className)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < className.Length; i++)
        {
            string even = className[i];
            if (!string.IsNullOrWhiteSpace(even))
            {
                //string odd =
                result.Append(even + className[++i]);
            }
        }
        return result.ToString();
    }


    public static string FromSpace160To32(string text)
    {
        text = Regex.Replace(text, @"\p{Z}", " ");
        return text;
    }

    public static bool IsNumber(string str, params char[] nextAllowedChars)
    {
        foreach (var item in str)
        {
            if (!char.IsNumber(item))
            {
                if (!nextAllowedChars.Contains(item))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static string MakeUpToXChars(int p, int p_2)
    {
        StringBuilder sb = new StringBuilder();
        string d = p.ToString();
        int doplnit = (p.ToString().Length - p_2) * -1;
        for (int i = 0; i < doplnit; i++)
        {
            sb.Append(0);
        }
        sb.Append(d);

        return sb.ToString();
    }

    public static char GetFirstChar(string arg)
    {
        return arg[0];
    }


}
