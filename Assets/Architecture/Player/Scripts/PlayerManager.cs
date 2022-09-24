using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager;
    private Controller controller;
    private PlayerAnimations playerAnimations;

    private bool isCanMove = true;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        controller = GetComponent<Controller>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
        playerAnimations.HandleAnimation();
    }

    private void FixedUpdate()
    {
        if(isCanMove)
        controller.HandleAllMovement();
    }

    public bool DisableMovement() => isCanMove = false;
    public bool EnableMovement() => isCanMove = true;
}
