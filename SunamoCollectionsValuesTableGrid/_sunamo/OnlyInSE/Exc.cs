using System.Diagnostics;
using System.Text;
namespace
#if SunamoCl
SunamoCl
#elif SunamoBts
SunamoBts
#elif SunamoChar
SunamoChar
#elif SunamoClipboard
SunamoClipboard
#elif SunamoDevCode
SunamoDevCode
#elif SunamoDictionary
SunamoDictionary
#elif SunamoFileSystem
SunamoFileSystem
#elif SunamoHtml
SunamoHtml
#elif SunamoLogging
SunamoLogging
#elif SunamoMail
SunamoMail
#elif SunamoPlatformUwpInterop
SunamoPlatformUwpInterop
#elif SunamoPS
SunamoPS
#elif SunamoSerializer
SunamoSerializer
#elif SunamoShared
SunamoShared
#elif SunamoString
SunamoString
#elif SunamoStringFormat
SunamoStringFormat
#elif SunamoStringJoin
SunamoStringJoin
#elif SunamoStringParts
SunamoStringParts
#elif SunamoStringSplit
SunamoStringSplit
#elif SunamoStringTrim
SunamoStringTrim
#elif SunamoArgs
SunamoArgs
#elif SunamoAsync
SunamoAsync
#elif SunamoAttributes
SunamoAttributes
#elif SunamoClearScript
SunamoClearScript
#elif SunamoCollectionOnDrive
SunamoCollectionOnDrive
#elif SunamoCollections
SunamoCollections
#elif SunamoCollectionsChangeContent
SunamoCollectionsChangeContent
#elif SunamoCollectionsGeneric
SunamoCollectionsGeneric
#elif SunamoCollectionsGenericShared
SunamoCollectionsGenericShared
#elif SunamoCollectionsIndexesWithNull
SunamoCollectionsIndexesWithNull
#elif SunamoCollectionsNonGeneric
SunamoCollectionsNonGeneric
#elif SunamoCollectionsShared
SunamoCollectionsShared
#elif SunamoCollectionsValuesTableGrid
SunamoCollectionsValuesTableGrid
#elif SunamoCollectionWithoutDuplicates
SunamoCollectionWithoutDuplicates
#elif SunamoColors
SunamoColors
#elif SunamoCompare
SunamoCompare
#elif SunamoConverters
SunamoConverters
#elif SunamoCrypt
SunamoCrypt
#elif SunamoDevCode
SunamoDevCode
#elif SunamoCsv
SunamoCsv
#elif SunamoData
SunamoData
#elif SunamoDateTime
SunamoDateTime
#elif SunamoDebugCollection
SunamoDebugCollection
#elif SunamoDebugging
SunamoDebugging
#elif SunamoDebugIO
SunamoDebugIO
#elif SunamoDelegates
SunamoDelegates
#elif SunamoEmbeddedResources
SunamoEmbeddedResources
#elif SunamoEnums
SunamoEnums
#elif SunamoEnumsHelper
SunamoEnumsHelper
#elif SunamoExceptions
SunamoExceptions
#elif SunamoExtensions
SunamoExtensions
#elif SunamoFileExtensions
SunamoFileExtensions
#elif SunamoFileIO
SunamoFileIO
#elif SunamoFluentFtp
SunamoFluentFtp
#elif SunamoFtp
SunamoFtp
#elif SunamoFubuCore
SunamoFubuCore
#elif SunamoFubuCsProjFile
SunamoFubuCsProjFile
#elif SunamoGitBashBuilder
SunamoGitBashBuilder
#elif SunamoGoogleSheets
SunamoGoogleSheets
#elif SunamoHttp
SunamoHttp
#elif SunamoIni
SunamoIni
#elif SunamoInterfaces
SunamoInterfaces
#elif SunamoJson
SunamoJson
#elif SunamoLang
SunamoLang
#elif SunamoLogMessage
SunamoLogMessage
#elif SunamoMarkdown
SunamoMarkdown
#elif SunamoMime
SunamoMime
#elif SunamoMsgReader
SunamoMsgReader
#elif SunamoNuGetProtocol
SunamoNuGetProtocol
#elif SunamoNumbers
SunamoNumbers
#elif SunamoNumbersShared
SunamoNumbersShared
#elif SunamoOctokit
SunamoOctokit
#elif SunamoPackageJson
SunamoPackageJson
#elif SunamoParsing
SunamoParsing
#elif SunamoPercentCalculator
SunamoPercentCalculator
#elif SunamoPInvoke
SunamoPInvoke
#elif SunamoRandom
SunamoRandom
#elif SunamoReflection
SunamoReflection
#elif SunamoRegex
SunamoRegex
#elif SunamoRoslyn
SunamoRoslyn
#elif SunamoRss
SunamoRss
#elif SunamoSolutionsIndexer
SunamoSolutionsIndexer
#elif SunamoStopwatch
SunamoStopwatch
#elif SunamoStringData
SunamoStringData
#elif SunamoStringGetLines
SunamoStringGetLines
#elif SunamoStringGetString
SunamoStringGetString
#elif SunamoStringJoinPairs
SunamoStringJoinPairs
#elif SunamoStringReplace
SunamoStringReplace
#elif SunamoStringShared
SunamoStringShared
#elif SunamoStringSubstring
SunamoStringSubstring
#elif SunamoText
SunamoText
#elif SunamoTextOutputGenerator
SunamoTextOutputGenerator
#elif SunamoThisApp
SunamoThisApp
#elif SunamoThread
SunamoThread
#elif SunamoTidy
SunamoTidy
#elif SunamoTwoWayDictionary
SunamoTwoWayDictionary
#elif SunamoTypeOfMessage
SunamoTypeOfMessage
#elif SunamoUnderscore
SunamoUnderscore
#elif SunamoUri
SunamoUri
#elif SunamoUriWebServices
SunamoUriWebServices
#elif SunamoValues
SunamoValues
#elif SunamoVcf
SunamoVcf
#elif SunamoWikipedia
SunamoWikipedia
#elif SunamoWinStd
SunamoWinStd
#elif SunamoXlfKeys
SunamoXlfKeys
#elif SunamoXliffParser
SunamoXliffParser
#elif SunamoXml
SunamoXml
#elif SunamoYaml
SunamoYaml
#elif SunamoYouTube
SunamoYouTube
#elif SunamoCollectionsTo
SunamoCollectionsTo
#elif SunamoGetFiles
SunamoGetFiles
#elif SunamoGetFolders
SunamoGetFolders
#elif SunamoXlfEngine
SunamoXlfEngine
#elif SunamoDictionaryToDelete
SunamoDictionaryToDelete
#elif SunamoDotnetCmdBuilder
SunamoDotnetCmdBuilder
#else
SunamoExceptions
#endif
;





public class Exc
{
    
    
    
    
    
    public static bool aspnet = false;
    #region For easy copy in SunamoException project
    private static bool first = true;
    private static readonly StringBuilder sb = new();
    
    
    public static string GetStackTrace(bool stopAtFirstSystem = false)
    {
        var r = GetStackTrace2(false, stopAtFirstSystem);
        return r.Item3;
    }
    
    
    
    
    
    public static Tuple<string, string, string>  GetStackTrace2(
    bool fillAlsoFirstTwo = true,
    bool stopAtFirstSystem = false)
    {
        if (stopAtFirstSystem)
            if (first)
                first = false;
        StackTrace st = new();
        var v = st.ToString();
        var l = v.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        
        l.RemoveAt(0);
        var i = 0;
        string type = null;
        string methodName = null;
        for (; i < l.Count; i++)
        {
            var item = l[i];
            if (fillAlsoFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    fillAlsoFirstTwo = false;
                }
            if (item.StartsWith("at System."))
            {
                
                
                l.Add(string.Empty);
                l.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, l));
    }
    
    
    
    
    
    
    
    public static void TypeAndMethodName(string l, out string type, out string methodName)
    {
        var s2 = l.Split("at ")[1].Trim();
        var s = s2.Split("(")[0];
        
        
        var p = s.Split(new char[] { AllChars.dot }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = p[p.Count - 1];
        p.RemoveAt(p.Count - 1);
        type = string.Join(AllStrings.dot, p);
    }
    public static bool _trimTestOnEnd = true;
    
    
    
    
    public static string CallingMethod(int v = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(v).GetMethod();
        var methodName = methodBase.Name;
        if (_trimTestOnEnd) methodName = SHSunamoExceptions.TrimEnd(methodName, "Test");
        return methodName;
    }
    #region MyRegion
    public static object lockObject = new();
    public static string MethodOfOccuredFromStackTrace(string exc)
    {
        var st = exc.Split(Environment.NewLine)[0];
        var dx = st.IndexOf(" in ");
        if (dx != -1) st = st.Substring(dx);
        return st;
    }
    
    
    
    
    
    private static List<string> GetLines(string v)
    {
        var l = v.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        return l;
    }
    #endregion
    #endregion
}
