namespace SunamoUriWebServices._sunamo;
internal class SHGetLines
{
    internal static List<string> GetLines(string v)
    {
        return v.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
