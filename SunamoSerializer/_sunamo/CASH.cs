using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class CASH
{
    public static void Replace(List<string> files_in, string what, string forWhat)
    {
        for (int i = 0; i < files_in.Count; i++)
        {
            files_in[i] = Replace(files_in[i], what, forWhat);
        }
        //CAChangeContent.ChangeContent2(null, files_in, Replace, what, forWhat);
    }

    static string Replace(string s, string from, string to)
    {
        return s.Replace(from, to);
    }
}

