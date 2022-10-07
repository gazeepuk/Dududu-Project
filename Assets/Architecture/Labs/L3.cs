using System;
using System.Diagnostics;
using System.Linq;

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
        arrWord = new char[inputText.Length];
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
        foreach (var item in arrWord)
        {
            foreach (var key in MyDictionary.ascii.Keys)
            {
                UnityEngine.Debug.Log("KEYS");
                if(item >= MyDictionary.ascii[key][0]  && item <= MyDictionary.ascii[key][0])
                {
                    if(toDecrypt)
                        newArrWord.Append(MyDictionary.GetSymbolWithDelta(key, item, -m));
                    else
                        newArrWord.Append(MyDictionary.GetSymbolWithDelta(key, item, m));
                }
            }
        }
        Array.Copy(newArrWord, arrWord, m);
        foreach (var item in newArrWord)
        {
            UnityEngine.Debug.Log(item);
        }
    }
}
