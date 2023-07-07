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
    bool isFootprint = false;
    //bool isForward = false;
    //bool isBackward = false;

    [SerializeField] GameObject ESC_menu;
    AudioSource audioSource;

    [Header("오디오 클립")]
    [SerializeField] AudioClip[] footprint = new AudioClip[5];
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip jumpLand;

    float x = 0;
    float z = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!GameManager.instance.isUIActivation)
        {
            isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGround && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            characterController.Move(move * speed * Time.deltaTime);

            if(!isFootprint && (x != 0 || z != 0))
            {
                isFootprint = true;
                StartCoroutine(FootprintSound_co());
            }


            if (Input.GetButtonDown("Jump") && isGround)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
                if (!isJump)
                {
                    isJump = true;
                    audioSource.clip = jump;
                    audioSource.Play();
                }
            }
            else if (isJump && isGround)
            {
                isJump = false;
                audioSource.clip = jumpLand;
                audioSource.Play();
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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                FindObjectOfType<ESCmenu>().ShowESC_UI();
            }
        }
    }

    IEnumerator FootprintSound_co()
    {
        while (true)
        {
            switch (isShift)
            {
                case true:
                    yield return new WaitForSeconds(0.2f);
                    break;
                case false:
                    yield return new WaitForSeconds(0.5f);
                    break;
            }

            if(isGround && (x!=0 || z != 0))
            {
                audioSource.clip = footprint[Random.Range(0, 5)];
                audioSource.Play();
            }
            else
            {
                isFootprint = false;
                StopAllCoroutines();
            }

        }
    }
}
