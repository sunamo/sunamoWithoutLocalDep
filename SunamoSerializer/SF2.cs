

namespace SunamoSerializer;

public partial class SF
{
    /// <summary>
    ///     Get all elements from A1
    ///     A2 byl object ale dal jsem ho jako string
    ///     nemůžu to dávat jako object protože SHSplit.Split musí být typový. Např. když mám allWhiteChars který je List
    ///     <object> a po přenesení do params string[] mi vytvoří new string[]{}
    /// </summary>
    /// <param name="var"></param>
    public static List<string> GetAllElementsLine(string var, string oddelovaciZnak = null)
    {
        if (oddelovaciZnak == null)
        {
            oddelovaciZnak = AllStrings.verbar;
        }
        // Musí tu být none, protože pak když někde nic nebylo, tak mi to je nevrátilo a progran vyhodil IndexOutOfRangeException
        return SHSplit.Split(var, oddelovaciZnak);
    }



    /// <summary>
    ///     In result A1 is not
    /// </summary>
    /// <param name="file"></param>
    /// <param name="hlavicka"></param>
    /// <param name="oddelovaciZnak"></param>
    public static (List<string> header, List<List<string>> rows)
         GetAllElementsFileAdvanced(string file,
        string oddelovaciZnak = "|")
    {
        if (oddelovaciZnak == null)
        {
            oddelovaciZnak = "|";
        }

        var hlavicka = new List<string>();
        string oz = oddelovaciZnak.ToString();
        List<List<string>> vr = new List<List<string>>();
        // Sync protože mám v deklaraci out
        List<string> lines = File.ReadAllLines(file).ToList();
        lines = CASE.Trim(lines);
        if (lines.Count > 0)
        {
            hlavicka = GetAllElementsLine(lines[0], oddelovaciZnak);
            int musiByt = lines[0].Split(new string[] { oz }, StringSplitOptions.None).Length - 1;
            //int nalezeno = 0;
            StringBuilder jedenRadek = new StringBuilder();

            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i].Trim().Length == 0)
                {
                    continue;
                }
                //nalezeno += SH.OccurencesOfStringIn(lines[i], oz);
                jedenRadek.AppendLine(lines[i]);
                //if (nalezeno == musiByt)
                //{
                //nalezeno = 0;
                List<string> columns = GetAllElementsLine(jedenRadek.ToString(), oddelovaciZnak);
                CASE.Trim(columns);
                jedenRadek.Clear();

                vr.Add(columns);
                //}
            }
        }

        return (hlavicka, vr);
    }
}
