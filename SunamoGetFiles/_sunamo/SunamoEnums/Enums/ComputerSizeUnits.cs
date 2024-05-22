namespace SunamoGetFiles;


internal enum ComputerSizeUnits : byte
{
    /// <summary>
    /// Když se má automaticky vyhodnotit nejsprávnější jednotka
    /// </summary>
    Auto = 0,
    B = 1,
    KB = 2,
    MB = 3,
    GB = 4,
    TB = 5
}