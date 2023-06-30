using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corral : MonoBehaviour
{
    [SerializeField] GameObject[] barrier = new GameObject[4];

    private void Start()
    {
        for(int i=0; i<4; i++)
        {
            barrier[i].SetActive(false);
        }
    }

    public void ActivationBarrier()
    {
        for (int i = 0; i < 4; i++)
        {
            barrier[i].SetActive(true);
        }
    }
}
