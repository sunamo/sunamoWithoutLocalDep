namespace SunamoSerializer;

/// <summary>
/// Is not allowed write empty elements - split of strings is running with StringSplitOptions.RemoveEmptyEntries
/// Tato třída je zde pouze kvůli GetTablesInDatabaseExportHandler.ashx.cs a General/ImportTables.aspx.cs
/// Snaž se tuto třídu nikdy nevyužívat a naopak vše ukládat do db, popř. stf/sbf
///
/// Pokud chci uložit jen cesty, je SF výborné, | v cestě se nemůže vyskytnout
/// Takto musím přemýšlet
///
/// </summary>
public static partial class SF
{
    public static int keyCodeSeparator
    {
        get
        {
            return (int)s_contentArgs.separatorChar;
        }
    }

    /// <summary>
    /// Must be property - I can forget change value on three occurences.
    /// </summary>
    public static char separatorChar
    {
        get
        {
            return s_contentArgs.separatorChar;
        }
    }

    static SF()
    {
        s_contentArgs.separatorString = AllStrings.verbar;
    }

    /// <param name = "element"></param>
    /// <param name = "line"></param>
    /// <param name = "elements"></param>
    private static string GetElementAtIndex(List<List<string>> elements, int element, int line)
    {
        if (elements.Count > line)
        {
            var lineElements = elements[line];
            if (lineElements.Count > element)
            {
                return lineElements[element];
            }
        }

        return null;
    }



    public static
#if ASYNC
    async Task<List<List<string>>>
#else
 List<List<string>>
#endif
 AppendAllText(string path, string line)
    {
        var content = (
#if ASYNC
    await
#endif
 File.ReadAllLinesAsync(path)).ToList();
        CASE.Trim(content);
        //content += Environment.NewLine + line + Environment.NewLine;
        content.Add(line);

        var vr = GetAllElementsLines(content);


#if ASYNC
        await
#endif
            File.WriteAllLinesAsync(path, content);

        return vr;
    }

    private static List<List<string>> GetAllElementsLines(List<string> lines)
    {
        string firstLine = null;
        return GetAllElementsLines(lines, ref firstLine);
    }

    private static List<List<string>> GetAllElementsLines(List<string> lines, ref string firstLIne)
    {
        lines = SF.RemoveComments(lines);

        List<List<string>> vr = new List<List<string>>();
        foreach (string var in lines)
        {
            if (!string.IsNullOrWhiteSpace(var))
            {
                vr.Add(SF.GetAllElementsLine(var));
            }
        }
        return vr;
    }

    /// <summary>
    /// If index won't founded, return null.
    /// </summary>
    /// <param name = "element"></param>
    /// <param name = "line"></param>
    public static string GetElementAtIndexFile(string file, int element, int line)
    {
        List<List<string>> elements = GetAllElementsFile(file);
        return GetElementAtIndex(elements, element, line);
    }

    /// <summary>
    /// G null if first element on any lines A2 dont exists
    /// </summary>
    /// <param name = "file"></param>
    /// <param name = "element"></param>
    public static List<string> GetFirstWhereIsFirstElement(string file, string element)
    {
        List<List<string>> elementsLines = SF.GetAllElementsFile(file);
        for (int i = 0; i < elementsLines.Count; i++)
        {
            if (elementsLines[i][0] == element)
            {
                return elementsLines[i];
            }
        }

        return null;
    }

    /// <summary>
    /// G null if first element on any lines A2 dont exists
    /// </summary>
    /// <param name = "file"></param>
    /// <param name = "element"></param>
    public static List<string> GetLastWhereIsFirstElement(string file, string element)
    {
        List<List<string>> elementsLines = SF.GetAllElementsFile(file);
        for (int i = elementsLines.Count - 1; i >= 0; i--)
        {
            if (elementsLines[i][0] == element)
            {
                return elementsLines[i];
            }
        }

        return null;
    }





    /// <summary>
    /// Read text with first delimitech which automatically delimite
    /// </summary>
    /// <param name="fileNameOrPath"></param>
    public static void ReadFileOfSettingsOther(string fileNameOrPath)
    {
        // COmmented, app data not should be in *.web. pass directly as arg
        List<string> lines = null;
        //SHGetLines.GetLines(AppData.ci.ReadFileOfSettingsOther(fileNameOrPath));
        if (lines.Count > 1)
        {
            int delimiterInt;
            if (int.TryParse(lines[0], out delimiterInt))
            {
                separatorString = ((char)delimiterInt).ToString();
            }
        }
    }

    public static async Task WriteAllElementsToFile(string VybranySouborLogu, List<string>[] p)
    {
        StringBuilder sb = new StringBuilder();
        foreach (List<string> item in p)
        {
            sb.AppendLine(PrepareToSerialization2(item));
        }

        await File.WriteAllTextAsync(VybranySouborLogu, sb.ToString());
    }


}
