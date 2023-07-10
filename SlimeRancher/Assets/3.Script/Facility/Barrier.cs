using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public int[] inSlimeCount = new int[2];

    private void Start()
    {
        inSlimeCount[0] = 0;
        inSlimeCount[1] = 0;
    }

    public void Update()
    {
        Debug.Log(gameObject.name + inSlimeCount[0] + "|" + inSlimeCount[1]);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slime") && other.gameObject.layer == 0)
        {
            other.gameObject.layer = 7;

            switch (other.GetComponent<Item>().itemNum)
            {
                case 1: //핑크슬라임
                    inSlimeCount[0]--;
                    break;
                case 2: //냥이슬라임
                    inSlimeCount[1]--;
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slime") && other.gameObject.layer == 0)
        {
            other.gameObject.layer = 7;

            switch (other.GetComponent<Item>().itemNum)
            {
                case 1: //핑크슬라임
                    inSlimeCount[0]++;
                    break;
                case 2: //냥이슬라임
                    inSlimeCount[1]++;
                    break;
            }
        }
    }


}
