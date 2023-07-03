using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corral : MonoBehaviour
{
    [SerializeField] List<GameObject> barrier = new List<GameObject>();

    public bool isLock = true;

    [SerializeField] GameObject corral_UI;

    private void Start()
    {
        if (isLock)
        {
            for (int i = 0; i < barrier.Count; i++)
            {
                barrier[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < barrier.Count; i++)
            {
                barrier[i].SetActive(true);
            }
        }
    }
    
    //���� ���� ������ ���Ѱ� �踮�� Ȱ��ȭ
    //�踮�� Ȱ��ȭ
    public void ActivationBarrier()
    {

        Debug.Log("�����Ͽ����ϴ�");
        for (int i = 0; i < barrier.Count; i++)
        {
            barrier[i].SetActive(true);
        }
    }

    public void ShowCorralUI()
    {
        corral_UI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ExitCorralUI()
    {
        corral_UI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
