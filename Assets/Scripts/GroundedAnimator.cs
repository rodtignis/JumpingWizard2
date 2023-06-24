using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedAnimator : MonoBehaviour
{
    private Animator animator;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask platformLayer;
    public GroundedAnimator grAnimr;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        // ��������� ���...

        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);

        // ��������� �������� isGrounded � GroundedAnimator
        grAnimr.isGrounded = isGrounded;

        // ��������� ���...
    }

  

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", isGrounded);
        }
    }
}
