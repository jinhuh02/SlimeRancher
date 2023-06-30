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
            if(bag[i] == itemNum && itemCount[i] < 20) //�̹� �κ��丮�� 1�� �̻� �����ϰ�, ������ 20���� ���� �ʾҴٸ�
            {
                objBox[i, itemCount[i]] = itemObj;
                objBox[i, itemCount[i]].SetActive(false);
                itemCount[i]++;
                Debug.Log(itemNum + " �� " + i + "�� ���濡 ���� | ���� " + itemCount[i] + "��");
                return;
            }
            else if (bag[i] == itemNum) //������ ���� ����
            {
                MaxItemCount();
                return;
            }
        }

        for(int i=0; i<4; i++)
        {
            if(bag[i] == 0) //ù ����
            {
                bag[i] = itemNum;
                objBox[i, 0] = itemObj;
                objBox[i, 0].SetActive(false);
                itemCount[i]++;
                Debug.Log(itemNum + " �� " + i + "�� ���濡 ���� | ���� " + itemCount[i] + "��");
                return;
            }
        }

        //�κ��丮 ĭ ����
        Debug.Log("�κ��丮 ĭ�� �����մϴ�!");

    }

    private void MaxItemCount() //������ ���� á�ٸ�
    {
        Debug.Log("������ ���� 20�� ����");
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.transform.CompareTag("Slime") || other.transform.CompareTag("Food") || other.transform.CompareTag("Item")) && other.transform.GetComponent<Item>().isVacpackSelect)
        {
            GetItem(other.transform.GetComponent<Item>().itemNum, other.gameObject);
        }
    }


    //��Ŭ������ �����Ǿ��ִ� �������� ��������
    public void ExportItem(int bagNum)
    {
        if (itemCount[bagNum] <= 0)
        {
            Debug.Log("������ �������� �����ϴ�");
            return;
        }

        objBox[bagNum, itemCount[bagNum]-1].SetActive(true);

        objBox[bagNum, itemCount[bagNum] - 1].transform.position = transform.position + (transform.rotation * Vector3.forward * 3);
        objBox[bagNum, itemCount[bagNum] - 1].GetComponent<Rigidbody>().velocity = Vector3.zero;
        objBox[bagNum, itemCount[bagNum] - 1].GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward * 1500, ForceMode.Force);
        itemCount[bagNum]--;

    }
}
