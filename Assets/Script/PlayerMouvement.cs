using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    //variables
    [SerializeField] private float movespeed;
    [SerializeField] private float walkspeed;
    [SerializeField] private float runspeed;

    private Vector3 movedirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundcheckdistance;
    [SerializeField] private LayerMask groundmask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpheight;

    //references
    private CharacterController controller;
    private Animator anim; 

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>(); 
    }
    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position , groundcheckdistance, groundmask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        movedirection = new Vector3(0, 0, moveZ);
        movedirection = transform.TransformDirection(movedirection);

        if (isGrounded)
        {
            if (movedirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if(movedirection!=Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (movedirection == Vector3.zero)
            {
                Idle();
            }

            movedirection *= movespeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }


        controller.Move(movedirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    private void Walk()
    {
        movespeed = walkspeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    private void Run()
    {
        movespeed = runspeed;
        anim.SetFloat("Speed", 1f, 0.1f,Time.deltaTime);
    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
    }
    private void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
