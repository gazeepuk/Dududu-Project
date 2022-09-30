using UnityEngine;
using TMPro;
public class L2_1 : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputText;
    [SerializeField]
    TMP_InputField mField;

    public bool ToDecrypt { get; set; }

    private void Awake()
    {
        ToDecrypt = false;
    }
    public void GenerateText()
    {
        if(inputText.text == null || !int.TryParse(mField.text, out var m))
        {
            mField.text = inputText.text = "Incorrect value";
            return;
        }

        var l2 = new L2(inputText.text, m);
        if(ToDecrypt)
            l2.DecryptText();
        else
            l2.EncryptText();
        inputText.text = l2.OutputText;
    }
}
