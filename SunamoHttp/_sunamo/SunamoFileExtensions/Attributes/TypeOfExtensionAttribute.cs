namespace SunamoHttp;


public class TypeOfExtensionAttribute : Attribute
{
    public TypeOfExtension Type { get; set; }
    public TypeOfExtensionAttribute(TypeOfExtension toe)
    {
        Type = toe;
    }
}