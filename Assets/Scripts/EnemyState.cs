using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum EnemyStates
    {
        Idle,
        Chase,
        Attack
    }

    [SerializeField]
    EnemyStates _currentState = EnemyStates.Idle;

    [SerializeField]
    private float speed = 2.25f;
    private float gravity = 9.81f;

    public CharacterController enemyController;
    public Transform player;

    private Vector3 velocity = Vector3.zero;
    private Vector3 direction = Vector3.zero;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    RaycastHit hit;
    public LayerMask playerMask;

    Animator animator;


    private void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        switch (_currentState)
        {
            case EnemyStates.Idle:
                LookForPlayer();
                break;
            case EnemyStates.Chase:
                Movement();
                break;
            case EnemyStates.Attack:
                AttackPlayer();
                break;
            default:
                break;
        }
    }

    private void LookForPlayer()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, playerMask))
        {
            Debug.Log("true");
            _currentState = EnemyStates.Chase;
        }
        else
        {
            Debug.Log("false");
            velocity = Vector3.zero;
            animator.SetBool("isWalking", false);
        }

    }

    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (enemyController.isGrounded)
        {
            direction = player.position - transform.position;
            direction.Normalize();
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
            velocity = direction * speed;
        }
        velocity.y -= gravity * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);

        animator.SetBool("isWalking", true);

        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, playerMask))
        {
            _currentState = EnemyStates.Idle;
        }
    }

    private void AttackPlayer()
    {

    }
}
