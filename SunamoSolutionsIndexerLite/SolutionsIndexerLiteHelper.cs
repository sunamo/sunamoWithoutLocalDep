using SunamoFileIO;
using SunamoFileSystem;
using SunamoPlatformUwpInterop.AppData;
using SunamoSolutionsIndexer.Data.SolutionFolderNs;

namespace SunamoSolutionsIndexerLite;

public class SolutionsIndexerLiteHelper
{
    static List<SolutionFolderSerializeLite> fwss = new List<SolutionFolderSerializeLite>();
    static string fCache = AppData.ci.GetFile(SunamoEnums.Enums.AppFolders.Cache, "SunamoSolutionsIndexerLiteSlnLists.txt");

    static async Task Reload(string folder)
    {
        var slns = Directory.GetFiles(folder, "*.sln", SearchOption.AllDirectories).ToList();

        await SaveToCache(slns);
        ProcessList(slns);
    }

    private static void ProcessList(List<string> slns)
    {
        foreach (var item in slns)
        {
            fwss.Add(new SolutionFolderSerializeLite() { fullPathFolder = item, displayedText = FS.GetFileName(FS.GetDirectoryName(item)) });
        }
    }

    public static async Task SaveToCache(List<string> l)
    {
        await TF.WriteAllLines(fCache, l);
    }

    public static async Task LoadFromCache()
    {
        if (File.Exists(fCache) && FS.LastModified(fCache) < DateTime.Now.AddHours(-24))
        {
            var d = await TF.ReadAllLines(fCache);
            ProcessList(d);
        }
        else
        {
            await Reload(fCache);
        }
    }

    public static SolutionFolderSerializeLite? SolutionWithName(string displayedText)
    {
        return fwss.FirstOrDefault(d => d.displayedText == displayedText);
    }
}
