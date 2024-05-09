namespace SunamoUriWebServices;

using SunamoData.Data;
using SunamoValues;
using System.Collections;
using System.Net;



public partial class UriWebServices
{
    public const string chromeSearchstringReplacement = "%s";
    public static Action<IList, string> SearchInAll;







    /// <summary>
    /// Just gray screen (22-12-2021)
    /// </summary>
    /// <param name="slnName"></param>
    /// <returns></returns>
    public static string AzureRepoWebUIFull(string slnName, AzureBuildUriArgs a = null)
    {
        var enc = WebUtility.UrlEncode(slnName);
        return AzureRepoWebUIDomain(a) + $"{enc}/_git/{enc}";
    }

    public static string AzureRepoWebUIDomain(AzureBuildUriArgs a = null)
    {
        return Consts.https + (a != null && a.withLogin ? "radekjancik@" : "") + (a != null && a.personalAccessToken != null ? a.personalAccessToken + "@" : "") + "radekjancik.visualstudio.com/";
    }


    public static string YouTubeProfile(string nick)
    {
        return "https://www.youtube.com/c/" + nick;
    }

    public static string TwitterProfile(string nick)
    {
        return "https://www.twitter.com/" + nick;
    }

    public static void AssignSearchInAll(Action<IList, string> assignSearchInAll)
    {
        SearchInAll = assignSearchInAll;
    }

    public static string FromChromeReplacement(string uri, string term)
    {
        // UrlEncode is not needed because not encode space to %20
        term = Uri.EscapeUriString(term);
        //term = UH.UrlEncode(term);
        return uri.Replace(chromeSearchstringReplacement, term);
    }
}
