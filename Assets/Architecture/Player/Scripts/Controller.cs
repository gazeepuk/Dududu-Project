using UnityEngine;


public class Controller : MonoBehaviour
{
    private CharacterController characterController;

    public AnimationCurve speedCurve;
    private float time = 0f;


    [SerializeField]
    private float speedMultiplpier = 1f;

    public float MovementSpeed { get; private set; }
    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private Transform groundCheker;
    [SerializeField]
    private float chackRadius = 0.1f;
    [SerializeField]
    private LayerMask groundLayer;
    public float Velocity { get; private set; }

    [SerializeField]
    private float jumpHeight = 3f;


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
        MovementSpeed = speedCurve.Evaluate(time) * Time.fixedDeltaTime * speedMultiplpier;

        if (moveDirection == Vector3.zero)
            time = 0f;
        else
            time += Time.fixedDeltaTime;

        moveDirection = inputManager.HorizontalInput * cameraObject.right + inputManager.VerticalInput * cameraObject.forward;
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        moveDirection.Normalize();

        if (moveDirection.magnitude >= 0.1f)
        {
            characterController.Move(moveDirection * Time.fixedDeltaTime * MovementSpeed);
            HandleRotation();
        }

    }

    private void HandleRotation()
    {
        float targrtAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targrtAngle, ref turnSmoothVelocity, 0.1f);
        transform.rotation = Quaternion.Euler(0, angle, 0);

    }
    public void Jump()
    {
        if (IsGrounded())
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
        Velocity += gravity * Time.fixedDeltaTime;
        characterController.Move(Vector3.up * Velocity * Time.fixedDeltaTime);
    }
}