namespace SunamoGetFolders;


/*
dříve dědila z GetFoldersEveryFolderArgs a ji dědil GetFilesArgs
Protože potřebuji univerzání data pro získávání souborů skrze různé metody (GetFiles, GetFilesMoreMasc atd.), vypadá teď takto
dávalo smysl i to co jsem měl, jelikož GetFilesEveryFolder
volalo GetFoldersEveryFolder takže jsem si z toho vzal jen subset z bázové třídy
*/
public class GetFilesBaseArgsGetFolders /*: GetFoldersEveryFolderArgs - nevracet - číst koment výše*/
{
    internal bool followJunctions = false;
    internal Func<string, bool> dIsJunctionPoint = null;
    internal bool _trimA1AndLeadingBs = false;
}