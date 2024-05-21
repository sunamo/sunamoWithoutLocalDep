using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoHttp;
internal class TF
{
    internal static string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }

    internal static void WriteAllBytes(string path, byte[] c)
    {
        File.WriteAllBytes(path, c);
    }
}
