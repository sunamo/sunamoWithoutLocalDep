namespace SunamoNumbersShared;

public class NHSH
{
    public static void RemoveEndingZeroPadding(List<byte> bajty)
    {
        for (int i = bajty.Count - 1; i >= 0; i--)
        {
            if (bajty[i] == 0)
            {
                bajty.RemoveAt(i);
            }
            else
            {
                break;
            }
        }
    }
}
