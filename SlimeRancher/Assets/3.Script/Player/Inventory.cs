using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    int[] bag = new int[4];
    int[] itemCount = new int[4];

    GameObject[,] objBox = new GameObject[4,20];

    [SerializeField] GameObject player;

    private void Start()
    {
        for(int i=0; i<4; i++)
        {
            bag[i] = 0;
            itemCount[i] = 0;
        }
    }

    public void GetItem(int itemNum, GameObject itemObj)
    {
        for(int i=0; i<4; i++)
        {
            if(bag[i] == itemNum && itemCount[i] < 20) //이미 인벤토리에 1개 이상 존재하고, 수량이 20개를 넘지 않았다면
            {
                objBox[i, itemCount[i]] = itemObj;
                objBox[i, itemCount[i]].SetActive(false);
                itemCount[i]++;
                Debug.Log(itemNum + " 를 " + i + "번 가방에 수납 | 현재 " + itemCount[i] + "개");
                return;
            }
            else if (bag[i] == itemNum) //아이템 개수 넘음
            {
                MaxItemCount();
                return;
            }
        }

        for(int i=0; i<4; i++)
        {
            if(bag[i] == 0) //첫 수납
            {
                bag[i] = itemNum;
                objBox[i, 0] = itemObj;
                objBox[i, 0].SetActive(false);
                itemCount[i]++;
                Debug.Log(itemNum + " 를 " + i + "번 가방에 수납 | 현재 " + itemCount[i] + "개");
                return;
            }
        }

        //인벤토리 칸 부족
        Debug.Log("인벤토리 칸이 부족합니다!");

    }

    private void MaxItemCount() //가방이 가득 찼다면
    {
        Debug.Log("아이템 수가 20개 넘음");
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.transform.CompareTag("Slime") || other.transform.CompareTag("Food") || other.transform.CompareTag("Item")) && other.transform.GetComponent<Item>().isVacpackSelect)
        {
            GetItem(other.transform.GetComponent<Item>().itemNum, other.gameObject);
        }
    }


    //좌클릭으로 수납되어있는 아이템을 내보낸다
    public void ExportItem(int bagNum)
    {
        if (itemCount[bagNum] <= 0)
        {
            Debug.Log("수납된 아이템이 없습니다");
            return;
        }

        objBox[bagNum, itemCount[bagNum]-1].SetActive(true);

        objBox[bagNum, itemCount[bagNum] - 1].transform.position = transform.position + (transform.rotation * Vector3.forward * 3);
        objBox[bagNum, itemCount[bagNum] - 1].GetComponent<Rigidbody>().velocity = Vector3.zero;
        objBox[bagNum, itemCount[bagNum] - 1].GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward * 1500, ForceMode.Force);
        itemCount[bagNum]--;

    }
}
