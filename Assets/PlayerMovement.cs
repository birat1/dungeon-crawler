using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;

    bool isMovingX;
    bool isMovingY;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 moveDir;

    // Update is called once per frame
    void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.y)) // diagonal check: when x/y is greater than other, disable it
        {
            moveDir.y = 0;
        }
        else
        {
            moveDir.x = 0;
        }
        Debug.Log($"X: {moveDir.x} Y: {moveDir.y}");

        if (moveDir != Vector2.zero)
        {
            animator.SetFloat("Horizontal", moveDir.x);
            animator.SetFloat("Vertical", moveDir.y);
        }    

        animator.SetFloat("Speed", moveDir.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
