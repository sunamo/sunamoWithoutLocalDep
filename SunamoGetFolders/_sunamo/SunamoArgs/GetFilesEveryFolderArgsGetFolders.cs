namespace SunamoGetFolders;


public class GetFilesEveryFolderArgsGetFolders : GetFilesBaseArgsGetFolders
{
    internal bool usePbTime = false;
    internal Action<double> InsertPbTime = null;
    internal Action<string> UpdateTbPb = null;
    internal bool usePb = false;
    internal Action<double> InsertPb = null;
    internal Action DoneOnePercent;
    internal Action Done;
    // return false if no to indexed. otherwise true
    internal Func<string, bool> FilterFoundedFiles;
    internal Func<string, bool> FilterFoundedFolders;
    internal int getNullIfThereIsMoreThanXFiles = -1;
}