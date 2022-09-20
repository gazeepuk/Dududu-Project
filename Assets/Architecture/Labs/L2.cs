using System;
public class L2
{
    class L2_1Task
    {
        public string Chiper { get; private set; }
        public L2_1Task(string text, int m)
        {
            Chiper = "";
            int n = (int)Math.Ceiling((double)text.Length / 3);

            n = n % 2 == 0 ? n : n+1;

            char[,] matrix = new char[m, n];

            for (int i = 0,c = 0; i < m; i++,c++)
            {
                for (int j = 0; j < n; j++,c++)
                {
                    matrix[j, i] = c < text.Length ? text[c] : ' ';
                }
            }

            foreach(char c in matrix)
            {
                Chiper += c;
            }
        }
    }
}
