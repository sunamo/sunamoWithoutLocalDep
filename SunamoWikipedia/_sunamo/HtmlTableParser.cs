using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoWikipedia;
/// <summary>
/// Protože klasický HtmlTableParser chce HtmlHelper který má miliardu deps
/// </summary>
public class HtmlTableParser
{
    public HtmlTableParser(object item, bool v)
    {
    }

    internal List<string> ColumnValues(string character, bool v1, bool v2)
    {
        ThrowEx.NotImplementedMethod();
        return null;
    }
}
