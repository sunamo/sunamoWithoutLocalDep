namespace
#if SunamoCollectionsGeneric
SunamoCollectionsGeneric
#elif SunamoCollectionsValuesTableGrid
SunamoCollectionsValuesTableGrid
#else
SunamoCollectionsGenericShared
#endif
;
public class CAGSH
{
    /// <summary>
    /// Get every item once
    /// A2 = more duplicities = more items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="clipboardL"></param>
    /// <param name="alreadyProcessed"></param>
    /// <returns></returns>
    public static List<T> GetDuplicities<T>(List<T> clipboardL, out List<T> alreadyProcessed)
    {
        alreadyProcessed = new List<T>(clipboardL.Count);
        List<T> duplicated = new List<T>();
        foreach (var item in clipboardL)
        {
            if (alreadyProcessed.Contains(item))
            {
                duplicated.Add(item);
            }
            else
            {
                alreadyProcessed.Add(item);
            }
        }
        duplicated = duplicated.Distinct().ToList();
        return duplicated;
    }
    /// <summary>
    /// Get every duplicated item once
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="clipboardL"></param>
    /// <returns></returns>
    public static List<T> GetDuplicities<T>(List<T> clipboardL)
    {
        List<T> alreadyProcessed;
        return GetDuplicities<T>(clipboardL, out alreadyProcessed);
    }
    /// <summary>
    /// Return equal ranges of in A1
    ///
    ///
    /// </summary>
    /// <param name="contentOneSpace"></param>
    /// <param name="r"></param>
    public static List<FromTo> EqualRanges<T>(List<T> contentOneSpace, List<T> r)
    {
        List<FromTo> result = new List<FromTo>();
        int? dx = null;
        var r_first = r[0];
        int startAt = 0;
        int valueToCompare = 0;
        for (int i = 0; i < contentOneSpace.Count; i++)
        {
            var _contentOneSpace = contentOneSpace[i];
            if (!dx.HasValue)
            {
                if (EqualityComparer<T>.Default.Equals(_contentOneSpace, r_first))
                {
                    dx = i + 1; // +2;
                    startAt = i;
                }
            }
            else
            {
                valueToCompare = dx.Value - startAt;
                if (r.Count > valueToCompare)
                {
                    if (EqualityComparer<T>.Default.Equals(_contentOneSpace, r[valueToCompare]))
                    {
                        dx++;
                    }
                    else
                    {
                        dx = null;
                        i--;
                    }
                }
                else
                {
                    int dx2 = (int)dx;
                    result.Add(new FromTo(dx2 - r.Count + 1, dx2, FromToUse.None));
                    dx = null;
                }
            }
        }
        foreach (var item in result)
        {
            item.from--;
            item.to--;
        }
        return result;
    }
    #region 2) IsEqualToAnyElement - For easy copy from CAContainsElementsOrTheirPartsShared
    /// <summary>
    /// ContainsAnyFromElement - Contains string elements of list. Return List<string>
    ///IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    ///IsEqualToAllElement - takes two generic list. return bool
    ///ContainsElement - at least one element must be equaled. generic. bool
    ///IsSomethingTheSame - only for string. as List.Contains. bool
    ///IsAllTheSame() - takes element and list.generic. bool
    ///IndexesWithValue() - element and list.generic. return list<int>
    ///ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="p"></param>
    /// <param name="list"></param>
    public static bool IsEqualToAnyElement<T>(T p, IList<T> list)
    {
        foreach (T item in list)
        {
            if (EqualityComparer<T>.Default.Equals(p, item))
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// CA.ContainsAnyFromElement - Contains string elements of list. Return List<string>
    /// CAG.IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    /// CA.IsEqualToAllElement - takes two generic list. return bool
    /// CA.ContainsElement - at least one element must be equaled. generic. bool
    /// CA.IsSomethingTheSame - only for string. as List.Contains. bool
    /// CA.IsAllTheSame() - takes element and list.generic. bool
    /// CA.IndexesWithValue() - element and list.generic. return list<int>
    /// CA.ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="p"></param>
    /// <param name="prvky"></param>
    /// <returns></returns>
    public static bool IsEqualToAnyElement<T>(T p, params T[] prvky)
    {
        return IsEqualToAnyElement(p, prvky.ToList());
    }
    #endregion
}