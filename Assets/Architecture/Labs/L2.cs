using System;
public class L2_1Task
{
    public string OutputText { get; private set; }
    public string InputText { get; private set; }

    private bool toDecrypt;
    private int m;
    private int n;
    private char[,] matrix;
    public L2_1Task(string text, int m, bool toDecrypt)
    {
        InputText = text;
        this.m = m;
        n = (int)Math.Ceiling((double)text.Length / m);
        matrix = new char[m, n];
        this.toDecrypt = toDecrypt;
        MakeMatrix();
    }

    private void MakeMatrix()
    {
        if (!toDecrypt)
            EncryptMatrix();
        else
            DecryptMatrix();
    }
    private void EncryptMatrix()
    {
        for (int i = 0, c = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (c < InputText.Length)
                {
                    matrix[j, i] = InputText[c];
                    c++;
                }
                else
                {
                    matrix[j, i] = ' ';
                }
            }
        }
    }

    private void DecryptMatrix()
    {
        for (int i = 0, c = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (c < InputText.Length)
                {
                    matrix[i, j] = InputText[c];
                    c++;
                }
                else
                {
                    matrix[i, j] = ' ';
                }
            }
        }
    }

    public void MakeOutputText()
    {
        OutputText = "";
        if (matrix != null)
        {
            if (!toDecrypt)
            {
                foreach (var item in matrix)
                {
                    OutputText += item;
                }
            }
            else
            {
                for (int i = 0; i < n; i++) 
                {
                    for (int j = 0; j < m; j++)
                    {
                        OutputText += matrix[j, i];
                    }
                }
            }
        }
        else
        {
            OutputText = "Input text is null";
        }
    }

}

public class L2_2Task
{
    private bool toEncrypt;
    private int[] arrNum;
    char[] arrWord;
    private string inputText;
    public string OutputText { get; private set; }
    public L2_2Task(string inputText, int size, bool toEncrypt)
    {
        switch (size)
        {
            case 5:
                arrNum = new int[25]
                {
                    21,24,2,3,15,
                    1,6,16,22,20,
                    14,12,19,7,13,
                    25,5,17,10,8,
                    4,18,11,23,9
                };
                break;
            case 6:
                arrNum = new int[36]
                {
                    22,36,7,2,9,35,
                    26,18,31,10,5,21,
                    13,23,15,24,28,8,
                    12,4,14,34,30,17,
                    6,1,33,25,19,27,
                    32,29,11,16,20,3
                };
                break;
            default:
                throw new Exception("Size must be 5 or 6");
        }
        arrWord = new char[size * size];
        this.inputText = inputText;
        this.toEncrypt = toEncrypt;
        if (toEncrypt)
            EncryptArray();
        else
            DecryptArray();
        MakeOutputText();
    }

    private void EncryptArray()
    {


        for (int i = 1, c = 0; i <= arrNum.Length; i++)
        {
            if (c < inputText.Length)
            {
                arrWord[Array.IndexOf(arrNum, i)] = inputText[c];
                c++;
            }
            else
                arrWord[Array.IndexOf(arrNum, i)] = '.';
        }
    }
    private void DecryptArray()
    {
        for (int i = 0, c = 0 ; i < arrNum.Length; i++)
        {
            if (c < inputText.Length)
            {
                arrWord[i] = inputText[c];
                c++;
            }
            else
                arrWord[i] = '.';
        }
    }

    private void MakeOutputText()
    {
        OutputText = "";
        if(toEncrypt)
        {
            foreach (var item in arrWord)
            {
                OutputText+=item;
            }
        }
        else
        {
            for(int i = 1, c = 0; i <= arrWord.Length; i++)
            {
                if (c < inputText.Length)
                {
                    UnityEngine.Debug.Log($"{arrWord.Length} {arrNum.Length} {Array.IndexOf(arrNum, i)}");
                 
                    OutputText += arrWord[Array.IndexOf(arrNum, i)];
                    c++;
                }
                else
                    OutputText += '.';
            }
        }
    }
}