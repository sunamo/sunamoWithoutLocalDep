using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoGetFiles;
internal class SHParts
{
    internal static string RemoveAfterLast(string nameSolution, object delimiter)
    {
        int dex = nameSolution.LastIndexOf(delimiter.ToString());
        if (dex != -1)
        {
            string s = nameSolution.Substring(0, dex); //SHSubstring.Substring(, 0, dex, new SubstringArgs());
            return s;
        }
        return nameSolution;
    }
}
