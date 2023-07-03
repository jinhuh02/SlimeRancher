using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{


    [SerializeField] GameObject my_barrier;
    [SerializeField] GameObject unlock_UI;

    //���� ������ ���� 250�� �Ѵ´ٸ� 
    //���� ���Ѱ� �踮�� ��Ȱ��ȭ
    public void Unlock_Barrier()
    {
        Debug.Log("�踮�� ����");

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
