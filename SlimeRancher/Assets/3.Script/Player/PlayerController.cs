using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    //[SerializeField] Animator animator;

    float speed = 20;
    float gravity = -20f;
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
        if (!GameManager.instance.isUIActivation)
        {
            isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGround && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            characterController.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGround)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
                if (!isJump)
                {
                    isJump = true;
                }
            }
            else if (isJump && isGround)
            {
                isJump = false;
            }


            if (isShift && Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 20;
                isShift = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isShift = true;
                speed = 40;
            }

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
