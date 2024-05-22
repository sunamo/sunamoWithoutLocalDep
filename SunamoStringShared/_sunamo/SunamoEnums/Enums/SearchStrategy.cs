namespace SunamoStringShared;


/// <summary>
/// FixedSpace - Contains
/// AnySpaces -
/// ExactlyName - Is exactly the same
/// </summary>
internal enum SearchStrategy
{
    /// <summary>
    /// Contains
    /// </summary>
    FixedSpace,
    /// <summary>
    /// split input by spaces and A1 must contains all parts
    /// </summary>
    AnySpaces,
    /// <summary>
    /// Is exactly the same
    /// </summary>
    ExactlyName
}