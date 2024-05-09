
namespace SunamoStringFormat._sunamo;
using SunamoExceptions;

internal class SHReplace
{
    internal static string ReplaceAll2(string vstup, string zaCo, string co, bool pairLines)
    {
        if (pairLines)
        {
            var from2 = SHSE.Split(co, Environment.NewLine);
            var to2 = SHSE.Split(zaCo, Environment.NewLine);
            ThrowEx.DifferentCountInLists("from2", from2, "to2", to2);

            for (int i = 0; i < from2.Count; i++)
            {
                vstup = ReplaceAll2(vstup, to2[i], from2[i]);
            }

            return vstup;
        }
        else
        {
            return ReplaceAll2(vstup, zaCo, co);
        }
    }

    internal static string ReplaceAll2(string vstup, string zaCo, string co)
    {
        return vstup.Replace(co, zaCo);
    }

