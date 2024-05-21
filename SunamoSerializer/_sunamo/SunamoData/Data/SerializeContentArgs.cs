namespace SunamoSerializer;


public class SerializeContentArgs
{
    /// <summary>
    /// Must be property - I can forget change value on three occurences. 
    /// </summary>
    public char separatorChar
    {
        get
        {
            return separatorString[0];
        }
    }
    public string separatorString = AllStrings.verbar;
    public int keyCodeSeparator
    {
        get
        {
            return separatorChar;
        }
    }
}