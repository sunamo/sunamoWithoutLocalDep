namespace SunamoUriWebServices;

using System.Web;


public partial class UriWebServices
{
    public static partial class TechSitesRss
    {
        public static Type type = typeof(TechSitesRss);

        public const string feedsFeedburnerCom = "http://feeds.feedburner.com/TechCrunch/";
        public const string wwwEngadgetCom = "http://www.engadget.com/rss.xml";

        /// <summary>
        /// Unknown rss feed
        /// </summary>
        public const string wwwThevergeCom = "http://www.theverge.com/rss/index.xml";

        public const string wwwSciencedailyCom = "https://www.sciencedaily.com/rss/all.xml";
        public const string wwwTechradarCom = "https://www.techradar.com/rss";
        public const string wwwWiredCom = "https://www.wired.com/feed/rss";
        public const string feedsArstechnicaCom = "http://feeds.arstechnica.com/arstechnica/index";
        public const string thenextwebCom = "https://thenextweb.com/feed/";
        public const string wwwTomshardwareCom = "https://www.tomshardware.com/feeds/all";

        public static List<string> haveImages = new List<string>(["thenextwebCom", "wwwEngadgetCom"]);
    }

    public static partial class YouTube
    {
        public static string GetLinkToSearch(string co)
        {
            return "https://www.youtube.com/results?search_query=" + HttpUtility.UrlEncode(co);
        }

        public static string GetLinkToVideo(string kod)
        {
            return ytVideoStart + kod;
        }

        public static string GetHtmlAnchor(string kod)
        {
            return "<a href='" + GetLinkToVideo(kod) + "'>" + kod + "</a>";
        }

        public const string ytVideoStart = "https://www.youtube.com/watch?v=";
    }
}
