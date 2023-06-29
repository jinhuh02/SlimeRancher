using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacpack : MonoBehaviour
{
    [SerializeField] Animator vacpack_animator;
    [SerializeField] GameObject[] meshs = new GameObject[5];


    bool mouseLeft = false;
    bool mouseRight = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !mouseRight)
        {
            mouseLeft = true;
            vacpack_animator.SetBool("mouseLeft", true);
            vacpack_animator.SetTrigger("lift");
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseLeft = false;
            vacpack_animator.SetBool("mouseLeft", false);
        }

        if (Input.GetMouseButtonDown(1) && !mouseLeft)
        {
            mouseRight = true;
            vacpack_animator.SetBool("mouseRight", true);
            vacpack_animator.SetTrigger("right");
            for (int i = 0; i < 5; i++)
            {
                meshs[i].SetActive(true);
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            mouseRight = false;
            vacpack_animator.SetBool("mouseRight", false);
            for (int i = 0; i < 5; i++)
            {
                meshs[i].SetActive(false);
            }
        }
    }


}
