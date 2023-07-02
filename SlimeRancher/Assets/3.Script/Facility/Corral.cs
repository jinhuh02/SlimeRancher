using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corral : MonoBehaviour
{
    [SerializeField] List<GameObject> barrier = new List<GameObject>();

    public bool isLock = true;

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


        for (int i = 0; i < barrier.Count; i++)
        {
            barrier[i].SetActive(true);
        }
    }
}
