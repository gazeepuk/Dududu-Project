using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class L3_3 : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputText;
    [SerializeField]
    TMP_InputField mField;

    [SerializeField]
    private ToggleCustom toggle;

    public bool ToDecrypt { get; set; }

    private void OnEnable()
    {
        toggle.OnToggleSetEvent += SetDecrypt;
    }

    private void OnDisable()
    {
        toggle.OnToggleSetEvent -= SetDecrypt;
    }

    private void SetDecrypt()
    {
        Debug.Log(toggle.IsToggleAvtive);
        ToDecrypt = toggle.IsToggleAvtive;
    }

    private void Awake()
    {
        ToDecrypt = false;
    }
    public void GenerateText()
    {
        foreach (var symb in inputText.text)
        {
            if(!(symb >= 'a' && symb <='z' || symb >= 'A' && symb <= 'Z'))
            {
                mField.text = inputText.text = "Incorrect value";
                return;
            }
        }
        if (mField.text.Any(char.IsDigit))   
        {
            mField.text = inputText.text = "Incorrect value";
            return;
        }
        var l3 = new L3_3Task(inputText.text, mField.text, ToDecrypt);
        inputText.text = l3.OutputText;
    }
}