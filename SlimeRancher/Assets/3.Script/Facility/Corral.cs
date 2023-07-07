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
        if(GameManager.instance.myCoin >= 250 && isLock)
        {
            Debug.Log("�����Ͽ����ϴ�");
            GameManager.instance.ComputeCoinValue(-250);
            AudioManager.instance.Play_RanchBuild();
            for (int i = 0; i < barrier.Count; i++)
            {
                barrier[i].SetActive(true);
            }
            isLock = false;
            this.enabled = false;
        }
    }

    public void ShowCorralUI()
    {
        corral_UI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        GameManager.instance.isUIActivation = true;
        AudioManager.instance.Play_UI_Activate();
    }

    public void ExitCorralUI()
    {
        corral_UI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.isUIActivation = false;
        AudioManager.instance.Play_UI_Exit();
    }
}
