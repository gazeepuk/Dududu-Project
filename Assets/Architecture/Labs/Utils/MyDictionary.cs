using System.Collections.Generic;

public class MyDictionary
{
    public static Dictionary<string, int[]> ascii = new Dictionary<string, int[]>()
    {
            {"engLowerCase", new int[]{97,122}},
            {"engUpperCase", new int[]{65,90}},
            {"numbers", new int[]{48,57}},
            {"symbols", new int[]{33,42}}
    };

    public static char GetSymbolWithDelta(string key, int charNum, int delta)
    {
        int newCharNum = charNum + delta;
        if(newCharNum > ascii[key][1])
        {
            newCharNum = ascii[key][0] + newCharNum - ascii[key][1] - 1;
            return (char)newCharNum;
        }
        else if(newCharNum < ascii[key][0])
        {
            newCharNum = ascii[key][0] - ascii[key][0] - newCharNum + 1;
        }
        return (char)newCharNum;
    }
}
