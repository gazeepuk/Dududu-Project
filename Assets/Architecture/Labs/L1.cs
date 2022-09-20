using System;
using System.Linq;
using System.Collections.Generic;

public class L1
{
    public double S { get; private set; }

    private Dictionary<string, int[]> ascii;

    private int amountOfSymbols;

    public int PasswordLength { get; private set; }

    public L1(double p, int v, int t)
    {
        ascii = MyDictionary.ascii;
        foreach (var array in ascii)
        {
            amountOfSymbols += array.Value[1] - array.Value[0] - 1;
        }
        S = Math.Ceiling(v*t/p);
        PasswordLength = (int)Math.Ceiling(Math.Log(S, amountOfSymbols));
    }
}
