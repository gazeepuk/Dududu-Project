using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private Controller controller;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<Controller>();
    }

    public void HandleAnimation()
    {
        animator.SetFloat("Velocity", controller.Velocity);
        animator.SetFloat("Speed",Mathf.Abs(controller.MovementSpeed));
        animator.SetBool("isGrounded", controller.IsGrounded());
    }
}
