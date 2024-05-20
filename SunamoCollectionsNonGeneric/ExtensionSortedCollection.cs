namespace
#if SunamoDevCode
SunamoDevCode
#else
SunamoCollectionsNonGeneric
#endif
;
/// <summary>
/// In values contains without extension
/// if file has no exception, will be grouped under empty string
/// All strings converts to lowercase
/// </summary>
public class ExtensionSortedCollection
{
    public Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
    /// <summary>
    /// Entries in A1 must be only filenames without paths
    /// </summary>
    /// <param name="d"></param>
    public ExtensionSortedCollection(params string[] d)
    {
        d.ToList().ForEach(fileName => AddOnlyFileName(fileName));
    }
    public void AddOnlyFileName(string fileName)
    {
        string key = Path.GetExtension(fileName).ToLower();
        string value = Path.GetFileNameWithoutExtension(fileName).ToLower();
        if (dictionary.ContainsKey(key))
        {
            if (!dictionary[key].Contains(value))
            {
                dictionary[key].Add(value);
            }
        }
        else
        {
            List<string> ad = new List<string>();
            ad.Add(value);
            dictionary.Add(key, ad);
        }
    }
    public void AddWholeFilePath(string filePath)
    {
        AddOnlyFileName(Path.GetFileName(filePath));
    }
}