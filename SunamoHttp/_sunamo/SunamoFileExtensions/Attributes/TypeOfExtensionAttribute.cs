namespace SunamoHttp;


internal class TypeOfExtensionAttribute : Attribute
{
    internal TypeOfExtension Type { get; set; }
    internal TypeOfExtensionAttribute(TypeOfExtension toe)
    {
        Type = toe;
    }
}