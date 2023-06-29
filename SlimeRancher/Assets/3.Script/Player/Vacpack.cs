using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacpack : MonoBehaviour
{
    [SerializeField] Animator vacpack_animator;
    [SerializeField] GameObject[] meshs = new GameObject[5];

    [Header("내보내기")]
    [SerializeField] Inventory inventory;
    [SerializeField] int itemBagNum = 0;

    bool mouseLeft = false;
    bool mouseRight = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !mouseRight)
        {
            mouseLeft = true;
            vacpack_animator.SetBool("mouseLeft", true);
            vacpack_animator.SetTrigger("lift");

            StartCoroutine(ExportItem_co());
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseLeft = false;
            vacpack_animator.SetBool("mouseLeft", false);

            StopAllCoroutines();
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

    IEnumerator ExportItem_co()
    {
        while (true)
        {
            inventory.ExportItem(itemBagNum);
            yield return new WaitForSeconds(0.3f);
        }
        
    }

}
