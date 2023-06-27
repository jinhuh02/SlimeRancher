using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    [SerializeField] float speed = 10;
    [SerializeField] float gravity = -9.81f;
    float jumpHeight = 3f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGround;
    bool isSpeedUp = false;

    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGround);

        if(isGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            Debug.Log("มกวม");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);    
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSpeedUp = true;
            speed = 20;
        }
        else if (isGround)
        {
            isSpeedUp = false;
            speed = 10;
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
