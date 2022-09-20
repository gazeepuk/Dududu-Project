using UnityEngine;

public class GroundCheckHandler : MonoBehaviour
{
    [SerializeField]
    private float radiusCheck;
    [SerializeField]
    LayerMask whatToCheckLayer;

    public static GroundCheckHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    public bool IsGrounded() => Physics.CheckSphere(transform.position, radiusCheck, whatToCheckLayer);
}
