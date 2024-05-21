namespace SunamoGetFiles;


// todo nemělo by to dědit z GetFoldersEveryFolderArgs? ve vs2 to tak mám
public class GetFilesArgs : GetFilesBaseArgs
{
    // todo s touhle třídou jsou jen problémy. udělat pořádek co tu má být a co tu nemám.
    public bool _trimExt = false;
    public bool _trimA1AndLeadingBs = false;
    public List<string> excludeFromLocationsCOntains = new List<string>();
    public bool dontIncludeNewest = false;
    /// <summary>
    /// Insert SunamoDevCodeHelper.RemoveTemporaryFilesVS etc.
    /// </summary>
    public Action<List<string>> excludeWithMethod = null;
    public bool byDateOfLastModifiedAsc = false;
    public Func<string, DateTime?> LastModifiedFromFn;
    /// <summary>
    /// 1-7-2020 changed to false, stil forget to mention and method is bad
    /// </summary>
    public bool useMascFromExtension = false;
    public bool wildcard = false;
}