using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacpack : MonoBehaviour
{
    [SerializeField] Animator vacpack_animator;
    [SerializeField] GameObject[] meshs = new GameObject[5];

    [Header("내보내기")]
    [SerializeField] Inventory inventory;

    bool mouseLeft = false;
    bool mouseRight = false;

    int selectInvenNum = 0;

    private void Update()
    {
        if (!GameManager.instance.isUIActivation)
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
                inventory.PlaySustainedAudio();
            }

            if (Input.GetMouseButtonUp(1))
            {
                mouseRight = false;
                vacpack_animator.SetBool("mouseRight", false);
                for (int i = 0; i < 5; i++)
                {
                    meshs[i].SetActive(false);
                }
                inventory.StopSustainedAudio();
            }


            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                if (selectInvenNum == 0)
                {
                    selectInvenNum = 3;
                }
                else
                {
                    selectInvenNum--;
                }
                inventory.ShowSelectUI(selectInvenNum);
                AudioManager.instance.Play_InventoryChainge(true);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                if (selectInvenNum == 3)
                {
                    selectInvenNum = 0;
                }
                else
                {
                    selectInvenNum++;
                }
                inventory.ShowSelectUI(selectInvenNum);
                AudioManager.instance.Play_InventoryChainge(false);
            }
        }
        
    }

    IEnumerator ExportItem_co()
    {
        while (true)
        {
            inventory.ExportItem(selectInvenNum);
            yield return new WaitForSeconds(0.3f);
        }

    }


}
