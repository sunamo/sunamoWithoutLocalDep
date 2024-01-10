namespace SunamoImageSharp;

/*
* System.Drawing.Common není a nebude multiplaformní
https://aka.ms/systemdrawingnonwindows
https://github.com/dotnet/runtime/issues/34959#issuecomment-885308638
*/
public class ImageSharpHelper
{
    public static void Save(Stream stream, ImageFormatIS format)
    {
        ThrowEx.NotImplementedMethod();
    }
}
