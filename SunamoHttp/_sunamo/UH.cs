using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoHttp;
public class UH
{
    public static string GetFileName(string uri)
    {
        return Path.GetFileName(uri);
    }
}
