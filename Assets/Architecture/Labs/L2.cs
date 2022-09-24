using System;
public class L2
{
    public string OutputText { get; private set; }
    public string InputText { get; private set; }
    private int m;
    private int n;
    private char[,] matrix;
    public L2(string text, int m)
    {
        InputText = text;
        this.m = m;
        n = (int)Math.Ceiling((double)text.Length / m);
        matrix = new char[m, n];
    }

    public void EncryptText()
    {
        EncryptMatrix();
        MakeOutputText();
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


    private void MakeOutputText()
    {
        OutputText = "";
        if (matrix != null)
            foreach (var item in matrix)
            {
                OutputText += item;
            }
        else
            OutputText = "Input text is null";
    }

}
