using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerControlHandler : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera playerCam;

    public void HandleControl()
    {
        var playerManager = GetComponent<PlayerManager>();
        if(playerCam.Priority <= 0)
        {
            playerManager.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            playerManager.enabled = true;
        }
    }
}
