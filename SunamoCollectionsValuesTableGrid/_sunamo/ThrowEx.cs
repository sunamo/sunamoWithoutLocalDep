namespace SunamoCollectionsValuesTableGrid._sunamo;
internal class ThrowEx
{
    internal static void DifferentCountInLists(string namefc, int countfc, string namesc, int countsc)
    {
        throw new Exception($"Different count in collections - {namefc} {countfc}, {namesc} {countsc}");
    }
}
