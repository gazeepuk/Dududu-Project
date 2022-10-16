using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using static UnityEditor.Progress;

public class L3_1Task
{
    public string InputText { get; private set; }
    public string OutputText { get; private set; }

    private bool toDecrypt;

    private char[] arrWord;

    private int m;
    public L3_1Task(string inputText, int m, bool toDecrypt)
    {
        InputText = inputText;
        arrWord = inputText.ToCharArray();
        this.m = m;
        this.toDecrypt = toDecrypt;
        GenerateArrWord();
        GenerateOutputText();
    }

    private void GenerateOutputText()
    {
        OutputText = "";
        foreach (var item in arrWord)
        {
            OutputText += item;
        }
    }

    private void GenerateArrWord()
    {
        var newArrWord = new char[arrWord.Length];
        var c = 0;
        foreach (var item in arrWord)
        {
            foreach (var key in MyDictionary.ascii.Keys)
            {
                if((int)item >= MyDictionary.ascii[key][0]  && item <= MyDictionary.ascii[key][1])
                {
                    if (toDecrypt)
                    {
                        var newChar = MyDictionary.GetSymbolWithDelta(key, (int)item, -m);
                        newArrWord[c] = newChar;
                    }
                    else
                    {
                        var newChar = MyDictionary.GetSymbolWithDelta(key, (int)item, m);
                        newArrWord[c] = newChar;
                    }
                }
            }
            c++;
        }
        Array.Copy(newArrWord, 0, arrWord, 0, arrWord.Length);
    }
}
public class L3_2Task
{
    public string InputText { get; private set; }
    public string OutputText { get; private set; }

    private bool toDecrypt;

    private char[] arrWord;

    public L3_2Task(string inputText, bool toDecrypt)
    {
        InputText = inputText;
        this.toDecrypt = toDecrypt;
        arrWord = new char[inputText.Length];
    }

    private void GenerateNewArrWord()
    {
        var newArrWord = new char[arrWord.Length];
        for (int posText = 1; posText <= arrWord.Length; posText++)
        {
            int m = 0;
            foreach (var key in MyDictionary.ascii.Keys)
            {
                if ((int)arrWord[posText] >= MyDictionary.ascii[key][0] && arrWord[posText] <= MyDictionary.ascii[key][1])
                {
                    if (toDecrypt)
                    {
                        var newChar = MyDictionary.GetSymbolWithDelta(key, (int)arrWord[posText], 0);
                        m = (int)newChar;
                    }
                    else
                    {
                        var newChar = MyDictionary.GetSymbolWithDelta(key, (int)arrWord[posText], 0);
                        m = (int)newChar;
                    }
                }
            }
            var k = 3 * posText * posText + 2 * posText + 1;
        }   
    }
}