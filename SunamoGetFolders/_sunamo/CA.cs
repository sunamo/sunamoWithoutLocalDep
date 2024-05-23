using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoGetFolders;
public class CA
{
    public static void RemoveWhichContains(List<string> files1, string item, bool wildcard, Func<string, string, bool> WildcardIsMatch)
    {
        if (wildcard)
        {
            //item = SH.WrapWith(item, AllChars.asterisk);
            for (int i = files1.Count - 1; i >= 0; i--)
            {
                if (WildcardIsMatch(files1[i], item))
                {
                    files1.RemoveAt(i);
                }
            }
        }
        else
        {
            for (int i = files1.Count - 1; i >= 0; i--)
            {
                if (files1[i].Contains(item))
                {
                    files1.RemoveAt(i);
                }
            }
        }
    }

    public static void RemoveWhichContainsList(List<string> files, List<string> list, bool wildcard, Func<string, string, bool> WildcardIsMatch = null)
    {
        foreach (var item in list)
        {
            RemoveWhichContains(files, item, wildcard, WildcardIsMatch);
        }
    }
}
