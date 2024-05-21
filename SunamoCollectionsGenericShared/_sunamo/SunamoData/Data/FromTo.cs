namespace SunamoCollectionsGenericShared;


/// <summary>
///     Must have always entered both from and to
///     None of event could have unlimited time!
/// </summary>
public class FromTo : FromToTSH<long>
{
    public static FromTo Empty = new(true);
    public FromTo()
    {
    }
    /// <summary>
    ///     Use Empty contstant outside of class
    /// </summary>
    /// <param name="empty"></param>
    private FromTo(bool empty)
    {
        this.empty = empty;
    }
    /// <summary>
    ///     A3 true = DateTime
    ///     A3 False = None
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="ftUse"></param>
    public FromTo(long from, long to, FromToUse ftUse = FromToUse.DateTime)
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
}