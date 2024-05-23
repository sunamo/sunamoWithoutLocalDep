using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoHttp;
public class TF
{
    public static string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }

    public static void WriteAllBytes(string path, byte[] c)
    {
        File.WriteAllBytes(path, c);
    }
}
