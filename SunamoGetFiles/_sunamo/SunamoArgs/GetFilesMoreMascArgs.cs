namespace SunamoGetFiles;


public class GetFilesMoreMascArgs : GetFilesBaseArgs
{
    internal bool LoadFromFileWhenDebug = false;
    internal string path;
    internal string masc = "*";
    internal SearchOption searchOption = SearchOption.TopDirectoryOnly;
    internal bool deleteFromDriveWhenCannotBeResolved = false;
}