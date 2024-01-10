namespace SunamoObjectDumperNet;

public class ObjectDumperNetHelper
{
    public static string Dump(object o)
    {
        return ObjectDumper.Dump(o);
    }
}
