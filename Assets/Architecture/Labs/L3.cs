using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

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
                    break;
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
        arrWord = inputText.ToCharArray();
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
            var k = 3 * c * c + 2 * c + 1;
            foreach (var key in MyDictionary.ascii.Keys)
            {
                if ((int)item >= MyDictionary.ascii[key][0] && item <= MyDictionary.ascii[key][1])
                {
                    if (toDecrypt)
                    {
                        var newChar = MyDictionary.GetSymbolWithDelta(key, (int)item, -k);
                        newArrWord[c] = newChar;
                    }
                    else
                    {
                        var newChar = MyDictionary.GetSymbolWithDelta(key, (int)item, k);
                        newArrWord[c] = newChar;
                    }
                    break;
                }
            }
            c++;
        }
        Array.Copy(newArrWord, 0, arrWord, 0, arrWord.Length);
    }
}
class L3_3Task
{
    class BiWord
    {
        public int[][] indexs;
        public BiWord()
        {
            indexs = new int[2][];
            indexs[0] = new int[2];
            indexs[1] = new int[2];
        }
    }
    private bool toDecrypt;
    public string InputText { get; private set; }
    public string OutputText { get; private set; }
    private char[,] arrWord = new char[5, 5];
    private List<string> biWords = new List<string>();
    private BiWord[] biWordsWithIndexs;
    public L3_3Task(string inputText, string key, bool toDecrypt)
    {
        this.toDecrypt = toDecrypt;
        OutputText = "";
        InputText = inputText;
        key = key.ToLower();
        InputText = InputText.ToLower();
        for (int symb = 'a'; symb <= 'z'; symb++)
        {
            if (symb != 'q')
                key += (char)symb;
        }
        InputText = InputText.Replace('q', 'k');
        var keyArr = key.ToCharArray().Distinct().ToArray();
        for (int i = 0, c = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++, c++)
            {
                arrWord[i, j] = keyArr[c];
            }
        }
        GenerateBiWords();
        MakeBiWords();
        ShuffleBiWords();
        MakeOutputText();
    }
    private void GenerateBiWords()
    {
        for (int i = 0; i < InputText.Length - 1; i++)
        {
            if (InputText[i] == InputText[i + 1])
                InputText = InputText.Insert(i + 1, "x");
        }
        if (InputText.Length % 2 != 0)
            InputText += "x";
        for (int i = 0; i < InputText.Length - 1; i += 2)
        {
            biWords.Add(InputText[i].ToString() + InputText[i + 1].ToString());
        }
    }
    private void MakeBiWords()
    {
        biWordsWithIndexs = new BiWord[biWords.Count];
        int c = 0;
        foreach (var biWord in biWords)
        {
            var biWordWithIndexs = new BiWord();
            for (int symbIndex = 0; symbIndex < 2; symbIndex++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (biWord[symbIndex] == arrWord[i, j])
                        {
                            biWordWithIndexs.indexs[symbIndex][0] = i;
                            biWordWithIndexs.indexs[symbIndex][1] = j;
                            break;
                        }
                    }
                }
            }
            biWordsWithIndexs[c] = biWordWithIndexs;
            c++;
        }
    }
    private void ShuffleBiWords()
    {
        var newBiWordsWithIndexs = new BiWord[biWordsWithIndexs.Length];
        int c = 0;
        foreach (var biWord in biWordsWithIndexs)
        {
            var biChar1 = biWord.indexs[0];
            var biChar2 = biWord.indexs[1];
            if (!toDecrypt)
            {
                if (biChar1[0] == biChar2[0])
                {
                    if (biChar1[1] + 1 > 4)
                        biChar1[1] = 0;
                    else
                        biChar1[1]++;

                    if (biChar2[1] + 1 > 4)
                        biChar2[1] = 0;
                    else
                        biChar2[1]++;

                }
                else if (biChar1[1] == biChar2[1])
                {
                    if (biChar1[0] + 1 > 4)
                        biChar1[0] = 0;
                    else
                        biChar1[0]++;

                    if (biChar2[0] + 1 > 4)
                        biChar2[0] = 0;
                    else
                        biChar2[0]++;

                }
                else
                {
                    int tempIndex = biChar1[1];
                    int tempIndex2 = biChar2[1];
                    biChar1[1] = tempIndex2;
                    biChar2[1] = tempIndex;
                }
            }
            else
            {
                if (biChar1[0] == biChar2[0])
                {
                    if (biChar1[1] - 1 < 0)
                        biChar1[1] = 4;
                    else
                        biChar1[1]--;

                    if (biChar2[1] - 1 < 0)
                        biChar2[1] = 4;
                    else
                        biChar2[1]--;

                }
                else if (biChar1[1] == biChar2[1])
                {
                    if (biChar1[0] - 1 < 0)
                        biChar1[0] = 4;
                    else
                        biChar1[0]--;

                    if (biChar2[0] - 1 < 0)
                        biChar2[0] = 4;
                    else
                        biChar2[0]--;

                }
                else
                {
                    int tempIndex = biChar1[1];
                    int tempIndex2 = biChar2[1];
                    biChar1[1] = tempIndex2;
                    biChar2[1] = tempIndex;
                }
            }
            newBiWordsWithIndexs[c] = biWord;
            c++;
        }
        biWordsWithIndexs = newBiWordsWithIndexs;
    }
    private void MakeOutputText()
    {
        OutputText = "";
        foreach (var biWord in biWordsWithIndexs)
        {
            OutputText += (arrWord[biWord.indexs[0][0], biWord.indexs[0][1]]).ToString() + (arrWord[biWord.indexs[1][0], biWord.indexs[1][1]]).ToString();
        }
    }

}