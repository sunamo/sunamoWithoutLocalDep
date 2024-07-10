
namespace SunamoRuleset;
using SunamoRuleset._sunamo;

public class RulesetValues
{
    #region rulesMicrosoftCodeQuality
    /// <summary>
    /// https://github.com/dotnet/roslyn-analyzers/blob/master/src/Microsoft.NetCore.Analyzers/Microsoft.NetCore.Analyzers.md
    /// https://docs.google.com/spreadsheets/d/1BeaQ1S41-iMJ5le7oO6V4r9Y9iSg2Du47_XVA37GPPk/edit#gid=0
    /// </summary>
    public static readonly List<string> rulesMicrosoftCodeQuality = SHGetLines.GetLines(@"CA1000
CA1001
CA1003
CA1008
CA1010
CA1012
CA1014
CA1016
CA1017
CA1018
CA1019
CA1021
CA1024
CA1027
CA1028
CA1030
CA1031
CA1032
CA1033
CA1034
CA1036
CA1040
CA1041
CA1043
CA1044
CA1050
CA1051
CA1052
CA1054
CA1055
CA1056
CA1060
CA1061
CA1062
CA1063
CA1064
CA1065
CA1066
CA1067
CA1068
CA1069
CA1200
CA1501
CA1502
CA1505
CA1506
CA1507
CA1508
CA1509
CA1707
CA1708
CA1710
CA1711
CA1712
CA1714
CA1715
CA1716
CA1717
CA1720
CA1721
CA1724
CA1725
CA1801
CA1802
CA1806
CA1812
CA1814
CA1815
CA1819
CA1821
CA1822
CA1823
CA2007
CA2011
CA2119
CA2200
CA2211
CA2214
CA2217
CA2218
CA2219
CA2224
CA2225
CA2226
CA2227
CA2231
CA2234
CA2244
CA2245
CA2246");
    #endregion

    #region rulesMicrosoftNetCoreAnalyzers
    /// <summary>
    /// https://github.com/dotnet/roslyn-analyzers/blob/master/src/Microsoft.CodeQuality.Analyzers/Microsoft.CodeQuality.Analyzers.md
    /// https://docs.google.com/spreadsheets/d/1by2sc_hiYWbJ_2N5v1ZBZHebkIRPCCYFydRu5Zi7bag/edit#gid=0
    /// </summary>
    public static readonly List<string> rulesMicrosoftNetCoreAnalyzers = SHGetLines.GetLines(@"CA1303
CA1304
CA1305
CA1307
CA1308
CA1309
CA1401
CA1810
CA1813
CA1816
CA1820
CA1824
CA1825
CA1826
CA1827
CA1828
CA1829
CA2000
CA2002
CA2008
CA2009
CA2010
CA2100
CA2101
CA2201
CA2207
CA2208
CA2213
CA2215
CA2216
CA2229
CA2235
CA2237
CA2241
CA2242
CA2243
CA2300
CA2301
CA2302
CA2305
CA2310
CA2311
CA2312
CA2315
CA2321
CA2322
CA2326
CA2327
CA2328
CA2329
CA2330
CA3001
CA3002
CA3003
CA3004
CA3005
CA3006
CA3007
CA3008
CA3009
CA3010
CA3011
CA3012
CA3061
CA5350
CA5351
CA5358
CA5359
CA5360
CA5361
CA5362
CA5363
CA5364
CA5365
CA5366
CA5367
CA5368
CA5369
CA5370
CA5371
CA5372
CA5373
CA5374
CA5375
CA5376
CA5377
CA5378
CA5379
CA5380
CA5381
CA5382
CA5383
CA5384
CA5385
CA5386
CA5387
CA5388
CA5389
CA5390
CA5391
CA5392
CA5393
CA5394
CA5395
CA5396
CA5397
CA5398
CA5399
CA5400
CA5401
CA5402
CA5403");
    #endregion
}
