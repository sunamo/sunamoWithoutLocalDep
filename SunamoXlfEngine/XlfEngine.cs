
namespace SunamoXlfEngine;
using SunamoCollectionWithoutDuplicates;
using SunamoDevCode.FileFormats;
using SunamoLang;


/// <summary>
/// Manage multilanguage strings in *.xlf files
/// Specific methods for working with Xlf from InsertIntoXlfAndConstantCsUC
/// </summary>
public class XlfEngine : ConstsManager
{
    static Type type = typeof(XlfEngine);

    #region Variables
    Dictionary<Langs, string> filesWithTranslation = new Dictionary<Langs, string>();
    public Langs l = Langs.cs;
    public bool requireUserDecision = false;
    /// <summary>
    /// Path to sunamo project (not solution)
    /// </summary>
    readonly string basePathXlf = null;

    public static XlfEngine Instance = new XlfEngine();
    public const string CopyWhileMassAddingNameFolder = "CopyWhileMassAdding";
    public bool waitingForUserDecision = false;
    /// <summary>
    /// Must be global because HotKey has delegate for handling method
    /// </summary>
    public string pascal = null;
    #endregion

    #region Init
    private XlfEngine() : base(System.IO.Path.Combine(DefaultPaths.sunamo, @"sunamo\Constants\XlfKeys.cs"), XmlLocalisationInterchangeFileFormat.IsToBeInXlfKeys)
    {
        basePathXlf = System.IO.Path.Combine(DefaultPaths.sunamo, "sunamo");
    }

    public static
#if ASYNC
    async Task
#else
    void
#endif
 GenerateEnumFromXlfKeys()
    {
        var keys =
#if ASYNC
            await
#endif
         XlfEngine.Instance.GetConsts();
        CSharpGenerator csg = new CSharpGenerator();
        List<EnumItem> ei = new List<EnumItem>();
        int id = 1;
        foreach (var item in keys.Item1)
        {
            ei.Add(new EnumItem { Name = item });
            id *= 2;
        }
        csg.Enum(0, AccessModifiers.Public, "KeysXlf", ei);

        var content = csg.ToString();

#if ASYNC
        await
#endif
        File.WriteAllTextAsync(DefaultPaths.KeysXlf, content);


        //ClipboardHelper.SetText(content);
    }

    /// <summary>
    /// With never convention is always saving to target trimmed all non digits/letters
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public string ToPascalConvention(string p)
    {
        return ConvertPascalConvention.ToConvention(p).TrimStart(AllChars.numericChars.ToArray());

        StringBuilder sb = new StringBuilder();
        bool dalsiVelke = false;
        foreach (char item in p)
        {
            if (char.IsLetterOrDigit(item))
            {
                if (dalsiVelke)
                {
                    if (char.IsUpper(item))
                    {
                        dalsiVelke = false;
                        sb.Append(item);
                        continue;
                    }
                    else if (char.IsLower(item))
                    {
                        dalsiVelke = false;
                        sb.Append(char.ToUpper(item));
                        continue;
                    }

                    else
                    {
                        //is number
                        dalsiVelke = false;
                        sb.Append(item);
                        continue;
                    }
                }
                else
                {
                    sb.Append(item);
                }
                //if (char.IsUpper(item))
                //{
                //    sb.Append(item);
                //}
                //else if (char.IsLower(item))
                //{
                //    sb.Append(item);
                //}
                //else
                //{
                //    dalsiVelke = true;
                //}
            }
            else if (AllLists.htmlEntitiesFullNames._d1.ContainsKey(item.ToString()))
            {
                sb.Append(AllStrings.lowbar + AllLists.htmlEntitiesFullNames._d1[item.ToString()]);
                dalsiVelke = true;
            }
            else
            {
                //Space etc. - dont add
                //sb.Append(item);
                dalsiVelke = true;
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Externally called from many places
    /// </summary>
    public Dictionary<Langs, string> InitializeMultilingualResources()
    {
        Dictionary<Langs, string> filesWithTranslation = new Dictionary<Langs, string>();
        #region Load strings from MultilingualResources file
        var path = Path.Combine(basePathXlf, "MultilingualResources\\");
        var files = Directory.GetFiles(path, "*.xlf", System.IO.SearchOption.TopDirectoryOnly);
        foreach (var item in files)
        {
            if (item.Contains("min"))
            {
                continue;
            }

            Langs l2 = XmlLocalisationInterchangeFileFormatSunamo.GetLangFromFilename(item);
            if (!filesWithTranslation.ContainsKey(l2))
            {
                filesWithTranslation.Add(l2, item);
            }
        }
        #endregion
        this.filesWithTranslation = filesWithTranslation;
        return filesWithTranslation;
    }
    #endregion

    public string englishTranslate = null;
    public CollectionWithoutDuplicates<string> en = null;
    public CollectionWithoutDuplicates<string> cs = null;

    #region Add
    public void AddCzech(string czechText, string key)
    {
        XmlLocalisationInterchangeFileFormat.Append(string.Empty, czechText, key, GetFile(Langs.cs));
    }

    public string GetFile(Langs cs)
    {
        if (filesWithTranslation.Count == 0)
        {
            filesWithTranslation = InitializeMultilingualResources();
        }
        return filesWithTranslation[cs];
    }

    public string AddEnglish(string englishText)
    {
        var key = XlfEngine.Instance.ToPascalConvention(englishText);
        AddEnglish(englishText, key);
        return key;
    }

    public void AddEnglish(string englishText, string key)
    {
        XmlLocalisationInterchangeFileFormat.Append(string.Empty, englishText, key, GetFile(Langs.en));
    }
    #endregion

    public
#if ASYNC
    async Task
#else
    void
#endif
 AddConstsWhichIsNotInXlfKeys(string v)
    {
        var d =
#if ASYNC
    await
#endif
 XmlLocalisationInterchangeFileFormat.GetTransUnits(v);
        d.FillIds();

        var consts =
#if ASYNC
            await
#endif
         XlfEngine.Instance.GetConsts();
        var keys = consts.Item1;
        int first = consts.Item2;

        List<string> toAdd = new List<string>();

        foreach (var item in d.allids)
        {
            if (!keys.Contains(item))
            {
                toAdd.Add(item);
            }
        }

        await XlfEngine.Instance.AddConsts(toAdd);
    }

    public const string d = "YouCameToThisPageBecauseYouTriedToLoadThePageOrToPerformAnotherOperationThatYouDoNotHavePermissionToDoOrThatIsNotApplicableInThisContext";

    /// <summary>
    /// NotFoundInDB
    /// </summary>
    public
#if ASYNC
    async Task
#else
    void
#endif
 RemoveFromXlfKeysWhichIsNotInXlfFile(string bp)
    {
        var path = XlfResourcesH.PathToXlfSunamo(Langs.en);

        var allids =
#if ASYNC
    await
#endif
 XmlLocalisationInterchangeFileFormat.GetIds(path);

        CAChangeContent.ChangeContent0(null, allids.Item1, d2 => "public const string " + d2 + " = \"" + d2 + "\";");

        await CSharpHelper.ReplaceForConsts(XlfEngine.Instance.pathXlfKeys);


        var consts =
#if ASYNC
            await
#endif
          XlfEngine.Instance.GetConsts();

        List<string> b = consts.Item3;
        int first = consts.Item2;

        var dx1 = b.IndexOf(d);

        var b2 = b.ToList();
        CA.RemoveStringsEmpty2(b2);
        CA.Trim(b2);

        var dx = b2.IndexOf(d);

        var both = CA.CompareList(b2, allids.Item1);

        CAChangeContent.ChangeContent0(null, allids.Item1, d4 => XmlLocalisationInterchangeFileFormatSunamo.GetConstsFromLine(d4));
        CAChangeContent.ChangeContent0(new ChangeContentArgs { removeNull = true }, b2, d4 => XmlLocalisationInterchangeFileFormatSunamo.GetConstsFromLine(d4));

        await CSharpParser.RemoveConsts(XlfEngine.Instance.pathXlfKeys, b2);

        AddKeysConsts(allids.Item1, first, b);
    }



    #region Methods


    /// <summary>
    /// Must be here coz use GetConsts - works with XlfKeys ant XlfEngine is only one class which can
    /// Return whether A1 is in XlfKeys
    /// if A2, save A1 to clipboard
    /// Externally called from InsertIntoXlfAndConstantCsUC.ClipboardMonitor_OnClipboardContentChanged
    /// </summary>
    /// <param name="pascal"></param>
    /// <param name="insertToClipboard"></param>
    public
#if ASYNC
        async Task<bool>
#else
        bool
#endif
     IsAlreadyContainedInXlfKeys(string pascal, bool insertToClipboard)
    {

        var consts =
#if ASYNC
                     await
#endif
         GetConsts();


        var keys = consts.Item1;
        int first = consts.Item2;

        if (keys.Contains(pascal))
        {
            if (insertToClipboard)
            {
                ClipboardHelper.SetText(pascal);
            }

            ThisApp.Info("Already " + pascal + " contained");
            return true;
        }
        return false;
    }

    /// <summary>
    /// Must be in XlfEngine coz use XlfDocument which is not imported in SunamoDevCode
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="l"></param>
    public void MergeWithAnotherXlf(string from, string to, Langs l)
    {
        var fileIdAlreadyExistsInXlf = AppData.ci.GetFile(AppFolders.Data, "AlreadyExistsInSunamoXlf_" + l + ".txt");
        PpkOnDrive ppk = new PpkOnDrive(fileIdAlreadyExistsInXlf);

        var dFrom = new XlfDocument(from);
        var dTo = new XlfDocument(to);

        var sFrom = XlfResourcesH.GetTransUnits(dFrom);
        var sTo = XlfResourcesH.GetTransUnits(dTo);

        foreach (var item in sFrom)
        {
            if (!sTo.ContainsKey(item.Key))
            {
                XmlLocalisationInterchangeFileFormat.Append(string.Empty, item.Value, item.Key, to);
            }
            else
            {
                var vTo = sTo[item.Key];
                ppk.Add(item.Key + "|" + item.Value);
            }
        }
    }
    #endregion
}
