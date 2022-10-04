using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ToggleL2_1 : MonoBehaviour
{
    [SerializeField]
    private Image toggleMark;
    private L2_1 generateButton;
    void Awake()
    {
        Debug.Log(toggleMark.name);
        generateButton = transform.parent.GetComponentInChildren<L2_1>();
        generateButton.ToDecrypt = toggleMark.gameObject.activeInHierarchy;
    }

    public void SetToggleMark()
    {
        toggleMark.gameObject.SetActive(!toggleMark.gameObject.activeSelf);
        generateButton.ToDecrypt = toggleMark.gameObject.activeSelf;
    }

}
