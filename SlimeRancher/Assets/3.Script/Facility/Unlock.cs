using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{


    [SerializeField] GameObject my_barrier;
    [SerializeField] GameObject unlock_UI;

    bool isLock =true;

    //가진 코인의 수가 250을 넘는다면 
    //코인 빼앗고 배리어 비활성화
    public void Unlock_Barrier()
    {   
        if (GameManager.instance.myCoin >= 250 && isLock)
        {
            Debug.Log("배리어 해제");
            GameManager.instance.ComputeCoinValue(-250);
            my_barrier.SetActive(false);
            isLock = false;
            this.enabled = false;
        }
    }


    public void ShowUnlockUI()
    {
        unlock_UI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        GameManager.instance.isUIActivation = true;
    }
    public void ExitUnlockUI()
    {
        unlock_UI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.isUIActivation = false;
    }


}
