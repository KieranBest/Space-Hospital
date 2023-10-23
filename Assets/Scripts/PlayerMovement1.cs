using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    Vector3 move;
    bool isGrounded;
    bool isRunning = false;
    bool isCrouched = false;

    void Update()
    {
        // Movement
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Jumping
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded)
        {
            move = transform.right * horizontal + transform.forward * vertical;
        }
        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouched)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && vertical > 0 && !isCrouched)
        {
            speed = 9f;
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            speed = 6f;
            isRunning = false;
        }

        // Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded && !isRunning)
        {
            speed = 1.5f;
            controller.height = 1.5f;
            isCrouched = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = 6f;
            controller.height = 3f;
            isCrouched = false;
        }
    }
}
