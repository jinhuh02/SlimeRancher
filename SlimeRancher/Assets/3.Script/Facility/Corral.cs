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
    
    //가진 코인 개수를 빼앗고 배리어 활성화
    //배리어 활성화
    public void ActivationBarrier()
    {


        for (int i = 0; i < barrier.Count; i++)
        {
            barrier[i].SetActive(true);
        }
    }
}
