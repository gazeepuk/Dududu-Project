using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ToggleCustom : MonoBehaviour
{
    public event System.Action OnToggleSetEvent;

    [SerializeField]
    private Image toggleMark;

    public bool IsToggleAvtive { get; private set; }

    void Awake()
    {
        IsToggleAvtive = toggleMark.gameObject.activeSelf;
    }

    public void SetToggleMark()
    {
        IsToggleAvtive = !toggleMark.gameObject.activeSelf;
        toggleMark.gameObject.SetActive(!toggleMark.gameObject.activeSelf);
        OnToggleSetEvent?.Invoke();
    }

}
