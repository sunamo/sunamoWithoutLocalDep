

namespace SunamoHttp;





/// <summary>
/// Náhrada za třídu NetHelper
/// Can be only in shared coz is not available in standard
/// </summary>
public static partial class HttpRequestHelperHttp
{

    public static bool IsNotFound(object uri)
    {
        HttpWebResponse r;
        var test = GetResponseText(uri.ToString(), HttpMethod.Get, null, out r);

        return HttpResponseHelperHttp.IsNotFound(r);
    }

    public static bool SomeError(object uri)
    {
        HttpWebResponse r;
        var test = GetResponseText(uri.ToString(), HttpMethod.Get, null, out r);

        return HttpResponseHelperHttp.SomeError(r);
    }

    /// <summary>
    /// A2 can be null (if dont have duplicated extension, set null)
    /// </summary>
    /// <param name="hrefs"></param>
    /// <param name="DontHaveAllowedExtension"></param>
    /// <param name="folder2"></param>
    /// <param name="co"></param>
    /// <param name="ext"></param>
    public static void DownloadAll(List<string> hrefs, BoolString DontHaveAllowedExtension, string folder2, FileMoveCollisionOption co, string ext = null)
    {
        if (co != FileMoveCollisionOption.Overwrite)
        {
            ThrowEx.Custom("Is allowed only Overwrite. Due to deps FS.MoveFile is not possible to use.");
        }

        foreach (var item in hrefs)
        {
            var tempPath = FS.GetTempFilePath();

            Download(item, DontHaveAllowedExtension, tempPath);
            var to = FS.Combine(folder2, Path.GetFileName(item) + ext);

            File.Move(tempPath, to, true);
        }
    }



    /// <summary>
    /// A2 can be null (if dont have duplicated extension, set null)
    /// In earlier time return ext
    /// Now return whether was downloaded
    /// </summary>
    /// <param name = "href"></param>
    /// <param name = "DontHaveAllowedExtension"></param>
    /// <param name = "folder2"></param>
    /// <param name = "fn"></param>
    /// <param name = "ext"></param>
    public static bool Download(string href, BoolString DontHaveAllowedExtension, string folder2, string fn, string ext = null)
    {
        if (DontHaveAllowedExtension != null)
        {
            if (DontHaveAllowedExtension(ext))
            {
                ext += ".jpeg";
            }
        }

        if (string.IsNullOrWhiteSpace(ext))
        {
            ext = FS.GetExtension(href);
            ext = SHParts.RemoveAfterFirst(ext, AllStrings.q);
        }

        fn = SHParts.RemoveAfterFirst(fn, AllStrings.q);
        string path = FS.Combine(folder2, fn + ext);
        FS.CreateFoldersPsysicallyUnlessThere(folder2);

        if (!FS.ExistsFile(path) || FS.GetFileSize(path) == 0)
        {
            var c = HttpRequestHelperHttp.GetResponseBytes(href, HttpMethod.Get);

            TF.WriteAllBytes(path, c);
            return true;
        }

        return false;
    }

    /// <summary>
    /// In earlier time return ext
    /// Now return whether was downloaded
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="DontHaveAllowedExtension"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool Download(string uri, BoolString DontHaveAllowedExtension, string path)
    {
        string p, fn, ext;
        FS.GetPathAndFileNameWithoutExtension(path, out p, out fn, out ext);
        return Download(uri, null, p, fn, FS.GetExtension(path));
    }
}
