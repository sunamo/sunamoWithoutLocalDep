
namespace SunamoUriWebServices;

using System.Diagnostics;
using System.Net;
using System.Web;



/// <summary>
/// vše co je s adresou musím encodovat
/// </summary>
public partial class UriWebServices
{
    static int opened = 0;
    public static string WikipediaEn = "https://en.wikipedia.org/w/index.php?search=%s";
    public const string karaokeTexty = "http://www.karaoketexty.cz/search?q=%s&sid=bbrpp&x=36&y=9";

    public const string instagramProfile = "https://www.instagram.com/{0}/";
    public const string heureka = "https://www.heureka.cz/?h[fraze]=%s&ss=1";
    public const string geocachingLog = "https://www.geocaching.com/play/geocache/%s/log";
    public const string amateriComCs = "https://www.amateri.com/cs/lide/search?search=%s";
    public const string amateriComEn = "https://www.amateri.com/en/lide/search?search=%s";

    /// <summary>
    /// Insert A1 to every in A2 with %s
    /// </summary>
    /// <param name="lyricsScz"></param>
    /// <param name="clipboardL"></param>
    public static void SearchAll(string lyricsScz, List<string> clipboardL)
    {
        foreach (var item in clipboardL)
        {
            opened++;
            Process.Start(FromChromeReplacement(lyricsScz, item));

            if (opened % 10 == 0)
            {
                Debugger.Break();
            }
        }
    }



    public static void SearchAll(Func<string, string> topRecepty, List<string> clipboardL)
    {

        foreach (var item in clipboardL)
        {
            opened++;
            Process.Start(topRecepty.Invoke(item));
            if (opened % 10 == 0)
            {
                Debugger.Break();
            }
        }
    }



    public static void GoogleSearch(List<string> list)
    {
        foreach (var item in list)
        {
            Process.Start(GoogleSearch(item));
        }
    }

    public static string SpritMonitor(string car)
    {
        // https://www.spritmonitor.de/en/overview/45-Skoda/1289-Citigo.html?fueltype=4
        string d = "cng overview -\"/detail/\"" + car;
        return GoogleSearchSite("spritmonitor.de", d);
    }



    public static string SearchGitHub(string item)
    {
        return "https://github.com/search?q=" + item;
    }

    public static string WebShare(string item)
    {
        return "https://webshare.cz/#/search?what=" + UrlEncode(item);
    }



    public static string GooglePlusProfile(string nick)
    {
        return "https://www.google.com/" + nick;
    }

    public static void GoogleSearchInAllSite(List<string> allRepairKitShops, string v)
    {
        foreach (var item in allRepairKitShops)
        {
            if (opened % 10 == 0 && opened != 0)
            {
                //Debugger.Break();
#if DEBUG

#endif

            }
            var uri = GoogleSearchSite(item, v);
            Process.Start(uri);
            opened++;
        }
    }

    //http://www.bdsluzby.cz/stavebni-cinnost/materialy.htm



    /// <summary>
    /// A1 už musí být escapováno
    /// </summary>
    /// <param name="s"></param>
    public static string GoogleSearch(string s)
    {
        // q for reviews in czech and not translated
        return "https://www.google.cz/search?hl=cs&q=" + UrlEncode(s);
    }

    public static string GoogleSearchImages(string s)
    {
        // q for reviews in czech and not translated
        return "https://www.google.cz/search?hl=cs&tbm=isch&q=" + UrlEncode(s);
    }

    public static string GoogleSearchSite(string site, string v)
    {
        site = site.Trim();

        var uri = new Uri(site);

        var host = string.Empty;
        if (uri != null)
        {
            host = uri.Host;
        }
        else
        {
            host = site.ToString();
        }

        //https://www.google.cz/search?q=site%3Asunamo.cz+s
        return "https://www.google.cz/search?q=site%3A" + host + "+" + UrlEncode(v);
    }


    /// <summary>
    /// Point to Repos tab
    /// Already new radekjancik
    /// Working with spaces right (SQL Server Scripts1)
    /// </summary>
    /// <param name="slnName"></param>
    public static string GitRepoInVsts(string slnName)
    {
        return "https://radekjancik.visualstudio.com/_git/" + WebUtility.UrlEncode(slnName);
    }

    /// <summary>
    /// Just gray screen (22-12-2021)
    /// </summary>
    /// <param name="slnName"></param>
    /// <returns></returns>
    public static string AzureRepoWebUIFull2(string slnName)
    {
        return null;
        // var enc = WebUtility.UrlEncode(slnName);
        // return $"https://radekjancik@dev.azure.com/radekjancik/{enc}/_git/{enc}";
    }

    public static string AzureRepoWebUI(string slnName, AzureBuildUriArgs a = null)
    {
        return AzureRepoWebUIDomain(a) + WebUtility.UrlEncode(slnName);
    }

    public static string AzureRepoWebUISettings(string slnName)
    {
        return AzureRepoWebUI(slnName) + "/_settings/";
    }

    public static string UrlEncode(string s)
    {
        return HttpUtility.UrlEncode(s);
    }
}
