namespace SunamoXliffParser._sunamo;

/*
Zde je to těžké
Prvně jsem to chtěl že SunExc bude 1. liga a ostatní jej budou používat
Teď to zase chci naopak, že ve sunexc chci používat i18n a proto je tu tato třída
SunamoExceptions -> SunamoI18N 24.1.9.1 -> SunamoXlf 24.1.7.4 -> SunamoXliffParser 24.1.1.1 -> SunamoExceptions (>= 24.1.1.3).
Hlavně už necpat xlfkeys do SunamoValues, tam nepatří a tyhle obecné package bych rád časem zrušil

až budu mít více energie, napravit tyto vzniklé situace
 */
internal class ThrowEx
{
    internal static void Custom(string v)
    {
        throw new NotImplementedException();
    }

    internal static void IsNull(string v)
    {
        throw new NotImplementedException();
    }
}
