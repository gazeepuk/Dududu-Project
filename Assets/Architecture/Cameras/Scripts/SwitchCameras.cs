using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchCameras : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera playerCamera;

    private bool isPlayerCameraActive = true;


    //Singletone
    public static SwitchCameras Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SwitchPriority(CinemachineVirtualCamera vcam2)
    {
        if (isPlayerCameraActive)
        {
            playerCamera.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            playerCamera.Priority = 1;
            vcam2.Priority = 0;
        }
        isPlayerCameraActive = !isPlayerCameraActive;
    }
}
