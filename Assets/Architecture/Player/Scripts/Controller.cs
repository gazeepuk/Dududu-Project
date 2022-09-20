using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class Controller : MonoBehaviour
{
    public AnimationCurve speedCurve;
    private float time = 0f;
    private CharacterController characterController;
    public float MovementSpeed { get; private set; }
    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private Transform groundCheker;
    [SerializeField]
    private float chackRadius = 0.1f;
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private float jumpHeight = 3f;

    public float Velocity { get; private set; }

    private InputManager inputManager;
    private Transform cameraObject;

    private Vector3 moveDirection;

    private float turnSmoothVelocity;
    private void Awake()
    {
        Velocity = 0f;
        characterController = GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
        cameraObject = Camera.main.transform;
        MovementSpeed = 0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheker.position, chackRadius);
    }

    public void HandleAllMovement()
    {
        Move();
        DoGravity();
    }

    public bool IsGrounded() => Physics.CheckSphere(groundCheker.position, chackRadius, groundLayer);
    private void Move()
    {
        MovementSpeed = speedCurve.Evaluate(time);
        if (moveDirection == Vector3.zero)
        {
            time = 0f;
        }
        else
            time += Time.fixedDeltaTime;

        moveDirection = inputManager.HorizontalInput*cameraObject.right + inputManager.VerticalInput*cameraObject.forward;
        moveDirection.Normalize();
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        if(moveDirection.magnitude >= 0.1f)
        {
            HandleRotation();
            characterController.Move(moveDirection * Time.fixedDeltaTime * MovementSpeed);

        }

    }

    private void HandleRotation()
    {
        float targrtAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targrtAngle, ref turnSmoothVelocity ,0.1f);
        transform.rotation = Quaternion.Euler(0, angle, 0);

    }
    public void Jump()
    {
        if(IsGrounded())
        Velocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
        characterController.Move(Vector3.up * Velocity * Time.fixedDeltaTime);
    }

    private void DoGravity()
    {
        if (IsGrounded())
        {
            Velocity = 0;
            return;
        }
        Velocity += gravity*Time.fixedDeltaTime;
        characterController.Move(Vector3.up * Velocity * Time.fixedDeltaTime);
    }
}
