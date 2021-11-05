using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardspeed;
    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between tow lanes
    public float jumpforce;
    public float gravity = -20;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }
    private void Update()
    {
        if (!playermanager.isgamestarted)
            return;
        direction.z = forwardspeed;

        //jumb
        if (controller.isGrounded)
            direction.y = -1;
          if (swipemanager.swipeUp)
          {
            Jump();
          }
        else
                direction.y += gravity * Time.deltaTime;

        // left or right
        if (swipemanager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (swipemanager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;

        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 150 * Time.deltaTime);
        controller.center = controller.center;
    }
    private void FixedUpdate()
    {
        if (!playermanager.isgamestarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void Jump()
    { 
        direction.y = jumpforce;
       /* StopCoroutine(Slide());
        animator.SetBool("isSliding", false);
        animator.SetTrigger("jump");
        controller.center = Vector3.zero;
        controller.height = 2;
        isSliding = false;

        velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);*/
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            playermanager.gameOver = true;
        }
    }
}