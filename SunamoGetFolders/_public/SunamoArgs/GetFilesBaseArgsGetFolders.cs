namespace SunamoGetFolders;



public class GetFilesBaseArgsGetFolders 
{
    public bool followJunctions = false;
    public Func<string, bool> dIsJunctionPoint = null;
    public bool _trimA1AndLeadingBs = false;
}