using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController playerController;
    private Controller controller;

    [SerializeField]
    private ExitWindow exitWindow;
    public Vector2 InputMovement { get; private set; }
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }

    private void Awake()
    {
        playerController = new PlayerController();
        controller = GetComponent<Controller>();
    }

    private void OnEnable()
    {
        playerController?.Enable();
        playerController.Player.Movement.performed += ctx => InputMovement = ctx.ReadValue<Vector2>();
        playerController.Player.Jump.started += _ => controller.Jump();
        playerController.Player.Exit.started += _ => exitWindow.SetExitWindowOn();

    }

    private void OnDisable()
    {
        playerController?.Disable();
        playerController.Player.Movement.performed -= ctx => InputMovement = ctx.ReadValue<Vector2>();
        playerController.Player.Jump.started -= _ => controller.Jump();
        playerController.Player.Exit.started -= _ => exitWindow.SetExitWindowOn();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        HorizontalInput = InputMovement.x;
        VerticalInput = InputMovement.y;
    }

}
