using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using Cinemachine;
public class ButtonInteract : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private CinemachineVirtualCamera vcam;

    private void Awake()
    {
        vcam = canvas.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.GetComponent<PlayerManager>())
        {
            Debug.Log("Player");
            SwitchCameras.Instance.SwitchPriority(vcam);
            SetCanvasOn();
        }
    }

    public void SetCanvasOn() => canvas.gameObject.SetActive(true);
}
