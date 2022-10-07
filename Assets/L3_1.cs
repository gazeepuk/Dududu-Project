using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class L3_1 : MonoBehaviour
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
        if (inputText.text == null || !int.TryParse(mField.text, out var m))
        {
            mField.text = inputText.text = "Incorrect value";
            return;
        }
        var l3 = new L3_1Task(inputText.text, m, ToDecrypt);
        inputText.text = l3.OutputText;

    }
}
