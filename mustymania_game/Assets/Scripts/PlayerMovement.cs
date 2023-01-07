using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    //public SpriteRenderer SpriteRenderer;
    //public Sprite Crouching;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        //SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch")) 
        {
            crouch = true;

        } 
        else if (Input.GetButtonUp("Crouch")) 
        {
            crouch = false;
        }

    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    public void onLanding()
    {
        animator.SetBool("IsFalling", false);
    }

    public void OnJumping()
    {
        animator.SetBool("IsJumping", true);
        animator.SetBool("IsFalling", false);
    }

    public void OnFalling()
    {
        animator.SetBool("IsFalling", true);
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() {

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
