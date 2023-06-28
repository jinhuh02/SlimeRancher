using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    //[SerializeField] Animator animator;

    float speed = 20;
    float gravity = -9.81f;
    float jumpHeight = 3f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGround = true;
    bool isJump = false;
    bool isShift = false;
    //bool isForward = false;
    //bool isBackward = false;

    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        //if (z > 0 && !isForward)
        //{
        //    isForward = true;
        //    isBackward = false;
        //    animator.SetTrigger("forward");
        //    animator.SetBool("isForward", isForward);
        //}
        //else if (z < 0 && !isBackward)
        //{
        //    isForward = false;
        //    isBackward = true;
        //    animator.SetTrigger("backward");
        //    animator.SetBool("isBackward", isBackward);
        //}
        //else if(z == 0)
        //{
        //    isForward = false;
        //    isBackward = false;
        //    animator.SetBool("isForward", isForward);
        //    animator.SetBool("isBackward", isBackward);
        //}

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
            if (!isJump)
            {
                isJump = true;
                //animator.SetBool("isGround", false);
            }
        }
        else if(isJump && isGround)
        {
            isJump = false;
            //animator.SetBool("isGround", true);
        }

        
        if (isShift && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //animator.SetBool("isShift", false);
            speed = 20;
            isShift = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //if (!isShift)
            //{
            //    animator.SetBool("isShift", true);
            //}
            isShift = true;
            speed = 40;
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }
}
