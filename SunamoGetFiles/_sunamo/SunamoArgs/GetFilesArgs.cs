namespace SunamoGetFiles;


// todo nemělo by to dědit z GetFoldersEveryFolderArgs? ve vs2 to tak mám
internal class GetFilesArgs : GetFilesBaseArgs
{
    // todo s touhle třídou jsou jen problémy. udělat pořádek co tu má být a co tu nemám.
    internal bool _trimExt = false;
    internal bool _trimA1AndLeadingBs = false;
    internal List<string> excludeFromLocationsCOntains = new List<string>();
    internal bool dontIncludeNewest = false;
    /// <summary>
    /// Insert SunamoDevCodeHelper.RemoveTemporaryFilesVS etc.
    /// </summary>
    internal Action<List<string>> excludeWithMethod = null;
    internal bool byDateOfLastModifiedAsc = false;
    internal Func<string, DateTime?> LastModifiedFromFn;
    /// <summary>
    /// 1-7-2020 changed to false, stil forget to mention and method is bad
    /// </summary>
    internal bool useMascFromExtension = false;
    internal bool wildcard = false;
}