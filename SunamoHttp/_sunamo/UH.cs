using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoHttp;
internal class UH
{
    internal static string GetFileName(string uri)
    {
        return Path.GetFileName(uri);
    }
}
