namespace SunamoUriWebServices;
public class SHGetLines
{
    public static List<string> GetLines(string v)
    {
        return v.Split(new string[] { v.Contains("\r\n") ? "\r\n" : "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
