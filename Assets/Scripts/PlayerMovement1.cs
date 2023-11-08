using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public CharacterController controller;

    public enum PlayerStates
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Crouching,
        Attack
    }

    [SerializeField]
    PlayerStates _currentState = PlayerStates.Idle;

    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private Vector3 moveDirection;
    private Vector3 jumpDirection;
    private Vector3 changeDirection;
    private bool isGrounded;
    private bool isRunning = false;
    private bool isCrouched = false;
    private bool jumped = false;


    public AudioSource audioSource;
    public AudioClip walkingAudio;
    public AudioClip jumpAudio;
    public AudioClip landingAudio;

    private void Update()
    {
        switch (_currentState)
        {
            case PlayerStates.Idle:
                PlayerIdle();
                break;
            case PlayerStates.Walking:
                PlayerWalkMovement();
                break;
            case PlayerStates.Running:
                PlayerRunMovement();
                break;
            case PlayerStates.Jumping:
                PlayerJumping();
                break;
            case PlayerStates.Crouching:
                PlayerCrouching();
                break;
            case PlayerStates.Attack:
                PlayerAttack();
                break;
            default:
                break;
        }
    }

    private void PlayerIdle()
    {
        isGrounded = true;
        // Movement
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && isGrounded)
        {
            _currentState = PlayerStates.Walking;
        }
        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _currentState = PlayerStates.Jumping;
        }
        // Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            _currentState = PlayerStates.Crouching;
        }
        
    }

    private void PlayerWalkMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        speed = 6f;
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(walkingAudio);
        }

        if (isGrounded)
        {
            moveDirection = transform.right * horizontal + transform.forward * vertical;
        }
        controller.Move(speed * Time.deltaTime * moveDirection);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Running
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && vertical > 0 && !isCrouched)
        {
            _currentState = PlayerStates.Running;
            isRunning = true;
        }
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouched)
        {
            _currentState = PlayerStates.Jumping;
        }
        // Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded && !isRunning)
        {
            _currentState = PlayerStates.Crouching;
        }
        // Idle
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            if (isGrounded)
            {
                _currentState = PlayerStates.Idle;
            }
        }
    }

    private void PlayerRunMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        speed = 9f;
        // audio file 

        if (isGrounded)
        {
            moveDirection = transform.right * horizontal + transform.forward * vertical;
        }
        controller.Move(speed * Time.deltaTime * moveDirection);

        // Walking
        if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            _currentState = PlayerStates.Walking;
            isRunning = false;
        }
        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouched)
        {
            _currentState = PlayerStates.Jumping;
        }
        // Idle
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && isGrounded)
        {
            _currentState = PlayerStates.Idle;
        }
    }

    private void PlayerJumping()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!jumped)
        {
            jumped = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpDirection = moveDirection;
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            changeDirection = transform.right * horizontal + transform.forward * vertical;
            moveDirection = (jumpDirection + changeDirection )/2;
        }
        controller.Move(speed * Time.deltaTime * moveDirection);
        controller.Move(velocity * Time.deltaTime);

        audioSource.PlayOneShot(jumpAudio);
        velocity.y += gravity * Time.deltaTime;

        // Landing
        if (isGrounded && velocity.y < 0)
        {
            jumped = false;
            velocity.y = -2f;
            audioSource.PlayOneShot(landingAudio);
            if (isRunning)
            {
                _currentState = PlayerStates.Running;
            }
            else if(isCrouched && !isRunning)
            {
                _currentState = PlayerStates.Crouching;
            }
            else
            {
                _currentState = PlayerStates.Walking;
            }
        }
        // Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded && !isRunning)
        {
            isCrouched = true;
        }
        // Standing
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouched = false;
        }
        // Walking
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
        // Running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
    }

    private void PlayerCrouching()
    {
        isCrouched = true;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        speed = 1.5f;
        controller.height = 1.5f;

        if (isGrounded)
        {
            moveDirection = transform.right * horizontal + transform.forward * vertical;
        }
        controller.Move(speed* Time.deltaTime* moveDirection);
        velocity.y += gravity* Time.deltaTime;
        controller.Move(velocity* Time.deltaTime);

        // Standing
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = 3f;
            velocity.y += gravity * Time.deltaTime;
            isCrouched = false;
            _currentState = PlayerStates.Walking;
        }
        // Idle
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (isGrounded)
            {
                controller.height = 3f;
                velocity.y += gravity * Time.deltaTime;
                isCrouched = false;
                _currentState = PlayerStates.Idle;
            }
        }
    }

    private void PlayerAttack()
    {
      
    }
}
