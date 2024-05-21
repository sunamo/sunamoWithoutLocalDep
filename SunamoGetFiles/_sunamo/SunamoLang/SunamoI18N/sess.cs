namespace SunamoGetFiles;


//namespace
//#if SunamoDevCode
//SunamoDevCode
//#elif SunamoGetFiles
//SunamoGetFiles
//#else
//SunamoLang
//#endif
//;
public class sess
{
    private static readonly Type type = typeof(sess);
    /// <summary>
    ///     Usage: Exceptions.IsNotWindowsPathFormat
    /// </summary>
    /// <param name="k"></param>
    /// <returns></returns>
    public static string i18n(string k)
    {
        switch (k)
        {
            case XlfKeys.isNotInWindowsPathFormat:
                return "is not in Windows Path format";
            case XlfKeys.NotImplementedCasePublicProgramErrorPleaseContactDeveloper:
                return "Not implemented case. public program error. Please contact developer";
            case XlfKeys.DifferentCountElementsInCollection:
                return "Different count elements in collection";
            default:
                ThrowEx.NotImplementedCase(k);
                break;
        }
        return null;
    }
}