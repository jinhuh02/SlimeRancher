using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{


    public GameObject my_barrier;
    [SerializeField] GameObject unlock_UI;

    public bool isLock =true;

    //���� ������ ���� 250�� �Ѵ´ٸ� 
    //���� ���Ѱ� �踮�� ��Ȱ��ȭ
    public void Unlock_Barrier()
    {   
        if (GameManager.instance.myCoin >= 250 && isLock)
        {
            Debug.Log("�踮�� ����");
            GameManager.instance.ComputeCoinValue(-250);
            AudioManager.instance.Play_RanchBuild();
            my_barrier.SetActive(false);
            isLock = false;

            FindObjectOfType<CurrentProgress>().isClearExpansionBarrier = true;

            this.enabled = false;
        }
    }


    public void ShowUnlockUI()
    {
        unlock_UI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        GameManager.instance.isUIActivation = true;
        AudioManager.instance.Play_UI_Activate();
    }
    public void ExitUnlockUI()
    {
        unlock_UI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.isUIActivation = false;
        AudioManager.instance.Play_UI_Exit();
    }


}
