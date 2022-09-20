using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class L1_1 : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField pField;
    [SerializeField]
    private TMP_InputField vField;
    [SerializeField]
    private TMP_InputField tField;

    [SerializeField]
    private TextMeshProUGUI sField;
    [SerializeField]
    private TextMeshProUGUI lField;

    private double p;
    private int v;
    private int t;

    public void GetP()
    {
        if(!double.TryParse(pField.text, out double pInput))
        {
            pField.text = "Incorrect value";
        }
        else
        {
            pField.selectionColor = Color.black;
        }

        p = pInput;
        Debug.Log(p);
    }

    public void GetV()
    {
        if (!int.TryParse(vField.text, out int vInput))
        {
            vField.text = "Incorrect value";
        }
        else
        {
            vField.selectionColor = Color.black;
        }

        v = vInput;
    }

    public void GetT()
    {
        if (!int.TryParse(tField.text, out int tInput))
        {
            tField.text = "Incorrect value";
        }
        else
        {
            tField.selectionColor = Color.black;
        }

        t = tInput;
    }

    public void GeneratePassword()
    {
        var text = GetComponent<TextMeshProUGUI>();
        if(p != 0 && v != 0 && t != 0)
        {
            L1 l1 = new L1(p, v, t);
            sField.text = $"S: {l1.S.ToString("e",new CultureInfo("en-US",false).NumberFormat)}";
            lField.text = $"Password length: {l1.PasswordLength}";
        }
        else
        {
            sField.text = lField.text = "Incorrect Values";
        }
    }
}
