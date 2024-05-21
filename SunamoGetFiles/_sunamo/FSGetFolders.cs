using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoGetFiles;
internal class FSGetFolders
{
    internal static List<string> GetFoldersEveryFolder(string folder, string v, GetFoldersEveryFolderArgs getFoldersEveryFolderArgs)
    {
        // implementaci která má za attr GetFoldersEveryFolderArgs jsem ztratil
        if (getFoldersEveryFolderArgs != null)
        {
            ThrowEx.Custom("There is some parameters in " + nameof(getFoldersEveryFolderArgs));
        }
        return Directory.GetDirectories(folder, v, SearchOption.AllDirectories).ToList();
    }
}
