using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class L2_2 : MonoBehaviour
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
        if (inputText.text == null || !int.TryParse(mField.text, out var m) || inputText.text.Length > m*m)
        {
            mField.text = inputText.text = "Incorrect value";
            return;
        }
        var l2 = new L2_2Task(inputText.text, m, !ToDecrypt);
        inputText.text = l2.OutputText;

    }
}
