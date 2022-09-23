using System;
using UnityEngine;
using TMPro;
public class L1_2 : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField aInput;
    [SerializeField]
    private TextMeshProUGUI passwordField;
    public void GeneratePassword()
    {
        var ascii = MyDictionary.ascii;
        var password = "";
        if (aInput.text == null)
            return;
        for (int i = 1; i <= 8; i++)
        {
            switch (i)
            {
                case 1:
                case 2:
                case 3:
                    password += PasswordGenerator.GenerateSymbol(ascii["numbers"]);
                    break;
                case 4:
                case 5:
                    password += PasswordGenerator.GenerateSymbol(ascii["symbols"]);
                    break;
                case 6:
                case 7:
                    password += PasswordGenerator.GenerateSymbol(ascii["engUpperCase"]);
                    break;
                case 8:
                    var passwordLength = aInput.text.Length;
                    var p = Convert.ToInt32(Math.Pow(passwordLength, 2) % 10 + Math.Pow(passwordLength, 3) % 10 + 1);
                    password += (char)(ascii["engLowerCase"][0] + p);
                    break;
            }
        }

        passwordField.text = $"Password: {password}";
    }
}
