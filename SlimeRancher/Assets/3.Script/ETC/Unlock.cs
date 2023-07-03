using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{


    [SerializeField] GameObject my_barrier;
    [SerializeField] GameObject unlock_UI;

    //가진 코인의 수가 250을 넘는다면 
    //코인 빼앗고 배리어 비활성화
    public void Unlock_Barrier()
    {
        Debug.Log("배리어 해제");

        my_barrier.SetActive(false);

    }


    public void ShowUnlockUI()
    {
        unlock_UI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void ExitUnlockUI()
    {
        unlock_UI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


}
