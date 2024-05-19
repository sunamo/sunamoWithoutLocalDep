namespace
#if SunamoDevCode
SunamoDevCode
#else
SunamoXliffParser
#endif
;

public interface IXlfExporter
    {
        void ExportTranslationUnits(string filePath, IEnumerable<XlfTransUnit> units, string targetLanguage,
            XlfDialect dialect);
    }
