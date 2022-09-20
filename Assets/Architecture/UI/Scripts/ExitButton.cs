using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class ExitButton : MonoBehaviour
{
    private Button exitButton;
    private CinemachineVirtualCamera vcam;
    private void Awake()
    {
        vcam = transform.parent.GetComponentInChildren<CinemachineVirtualCamera>();
        exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(SetCanvasOff);
        exitButton.onClick.AddListener(SwitchPriority);
    }

    private void SetCanvasOff()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void SwitchPriority()
    {
        SwitchCameras.Instance.SwitchPriority(vcam);
    }
}
