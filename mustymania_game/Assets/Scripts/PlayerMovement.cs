using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public SpriteRenderer SpriteRenderer;
    public Sprite Standing;
    public Sprite Crouching;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Standing;
    }

    // Update is called once per frame
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            crouch = true;
            SpriteRenderer.sprite = Crouching;

        } else if (Input.GetKeyUp(KeyCode.C)) {
            crouch = false;
            SpriteRenderer.sprite = Standing;
        }

    }

    void FixedUpdate() {

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
