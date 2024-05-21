using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoGetFolders;
internal class FSGetFiles
{
    internal static List<string> GetFiles(string item, string masc, SearchOption topDirectoryOnly)
    {
        return Directory.GetFiles(item, masc, topDirectoryOnly).ToList() ;
    }
}
