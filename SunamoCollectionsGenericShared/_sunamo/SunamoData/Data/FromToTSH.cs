namespace SunamoCollectionsGenericShared;


public class FromToTSH<T>
{
    
    public bool empty;
    protected long fromL;
    public FromToUse ftUse = FromToUse.DateTime;
    protected long toL;
    public FromToTSH()
    {
        var t = typeof(T);
        if (t == Types.tInt) ftUse = FromToUse.None;
    }
    /// <summary>
    ///     Use Empty contstant outside of class
    /// </summary>
    /// <param name="empty"></param>
    private FromToTSH(bool empty) : this()
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
    public FromToTSH(T from, T to, FromToUse ftUse = FromToUse.DateTime) : this()
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
    public T from
    {
        get => (T)(dynamic)fromL;
        set => fromL = (long)(dynamic)value;
    }
    public T to
    {
        get => (T)(dynamic)toL;
        set => toL = (long)(dynamic)value;
    }
    public long FromL => fromL;
    public long ToL => toL;
}