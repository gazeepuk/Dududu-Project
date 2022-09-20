using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocalMovement : MonoBehaviour
{
    private InputManager inputManager;
    private Transform cameraObject;
    private Vector3 moveDirection;
    private Rigidbody rb;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float movementSpeed;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 horizontalMovement = cameraObject.right * inputManager.HorizontalInput;
        Vector3 verticalMovement = cameraObject.forward * inputManager.VerticalInput;
        moveDirection = horizontalMovement + verticalMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;
        rb.velocity = moveDirection * movementSpeed;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = moveDirection;
        if(targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

        transform.rotation = playerRotation;
    } 
}
