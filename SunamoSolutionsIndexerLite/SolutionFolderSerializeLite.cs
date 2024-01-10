using SunamoFileExtensions;
using SunamoFileSystem;
using SunamoSolutionsIndexer.Data.SolutionFolderNs;
using SunamoSolutionsIndexer.Interfaces;
using SunamoValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoSolutionsIndexerLite;
public class SolutionFolderSerializeLite : ISolutionFolderSerialize /* : SolutionFolderSerialize*/
{
    public string displayedText { get; set; } = string.Empty;
    public string fullPathFolder { get; set; } = string.Empty;

    public string LongName => throw new NotImplementedException();

    public string nameSolution => throw new NotImplementedException();

    public string RunOne => throw new NotImplementedException();

    public string ShortName => throw new NotImplementedException();

    public string ExeToRelease(ISolutionFolderSerialize sln, string projectDistinction, bool standaloneSlnForProject, bool addProtectedWhenSelling = false, bool publish = false)
    {
#if DEBUG
        if (sln.nameSolution.Contains("GitForDebug") || projectDistinction.Contains("Wpf"))
        {

        }
#endif
        // zde můžu přiřadit jen ty co skutečně existují
        string existingExeReleaseFolder = null;
        // 
        var solutionFolder = sln.fullPathFolder.TrimEnd(AllCharsSE.bs);

        var exeName = sln.nameSolution;
        string exeNameWithExt = exeName + AllExtensions.exe;

        var projectFolderPath = Path.Combine(solutionFolder, exeName);

        if (!FS.ExistsDirectory(projectFolderPath))
        {
            return null;
        }

        var bp = Path.Combine(projectFolderPath, @"bin\");

        string p1 = null;
#if DEBUG
        if (sln.nameSolution.Contains("ConsoleApp1") || projectDistinction.Contains("Wpf"))
        {

        }
#endif

        #region MyRegion
        var baseReleaseFolder = Path.Combine(projectFolderPath, @"bin\Release\");
        var net7 = Path.Combine(baseReleaseFolder, "net8.0\\");
        var net7Windows = Path.Combine(baseReleaseFolder, "net8.0-windows\\");

        if (publish)
        {
            net7 += "win-x64\\publish\\";
            net7Windows += "win-x64\\publish\\";
        }

        var b1 = FS.ExistsDirectory(net7);
        var b2 = FS.ExistsDirectory(net7Windows);

        string exePath = null;

        if (b1)
        {
            exePath = FS.Combine(net7, exeName + ".exe");
            if (FSSE.ExistsFile(exePath))
            {
                existingExeReleaseFolder = net7;
            }
            else
            {
                existingExeReleaseFolder = FindExistingFolderWithRightArchitecture(net7, exeNameWithExt);
            }
        }
        if (b2 && existingExeReleaseFolder == null)
        {
            exePath = FS.Combine(net7Windows, exeName + ".exe");
            if (FSSE.ExistsFile(exePath))
            {
                existingExeReleaseFolder = net7Windows;
            }
            else
            {
                existingExeReleaseFolder = FindExistingFolderWithRightArchitecture(net7Windows, exeNameWithExt);
            }
        }
        #endregion

        // Kontroluje mi pouze na cestu zda existuje. soubor jako takový nemusí existovat
        //if (FS.ExistsFile(net4))
        //{
        //    return null;
        //}

#if DEBUG
        if (sln.nameSolution.Contains("ConsoleApp1") || projectDistinction.Contains("Wpf"))
        {

        }
#endif

        if (existingExeReleaseFolder == null)
        {
            return null;
        }

        var result = FS.Combine(existingExeReleaseFolder, exeNameWithExt);
        return result;
    }

    private string FindExistingFolderWithRightArchitecture(string net7, string exeNameWithExt)
    {
        // https://learn.microsoft.com/en-us/dotnet/core/rid-catalog
        var maybe = FS.Combine(net7, "win-x64", exeNameWithExt);

        if (FSSE.ExistsFile(maybe))
        {
            return FSSE.GetDirectoryName(maybe);
        }

        maybe = FS.Combine(net7, "win-x86", exeNameWithExt);

        if (FSSE.ExistsFile(maybe))
        {
            return FSSE.GetDirectoryName(maybe);
        }

        return null;
    }
}
