using System;
public class L2
{
    public string OutputText { get; private set; }
    public string InputText { get; private set; }

    private bool toDecrypt;
    private int m;
    private int n;
    private char[,] matrix;
    public L2(string text, int m, bool toDecrypt)
    {
        InputText = text;
        this.m = m;
        n = (int)Math.Ceiling((double)text.Length / m);
        matrix = new char[m, n];
        this.toDecrypt = toDecrypt;
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

    public void MakeOutputText()
    {
        OutputText = "";
        if (matrix != null)
        {
            UnityEngine.Debug.Log("MAKE");
            if (!toDecrypt)
            {
                UnityEngine.Debug.Log("Encrypt");
                foreach (var item in matrix)
                {
                    UnityEngine.Debug.Log(item);
                    OutputText += item;
                }
                UnityEngine.Debug.Log(OutputText);
            }
            else
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        OutputText += matrix[i, j];
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
