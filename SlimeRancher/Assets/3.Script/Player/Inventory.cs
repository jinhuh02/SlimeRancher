using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    int[] bag = new int[4];
    int[] itemCount = new int[4];

    GameObject[,] objBox = new GameObject[4,20];

    [SerializeField] GameObject player;


    [SerializeField] GameObject[] SelectedUI = new GameObject[4]; //�������� Ű���ֱ�����
    [SerializeField] GameObject[] UnselectedUI = new GameObject[4]; //x
    [SerializeField] Image[] icon_UI = new Image[4];
    [SerializeField] Text[] name_UI = new Text[4];
    [SerializeField] Text[] count_UI = new Text[4];

    private void Start()
    {
        for(int i=0; i<4; i++)
        {
            bag[i] = 0;
            itemCount[i] = 0;
            UnselectedUI[i].SetActive(true);
            icon_UI[i].gameObject.SetActive(false);
            name_UI[i].text = string.Empty;
            count_UI[i].text = string.Empty;
        }

        SelectedUI[0].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void ShowSelectUI(int selectNum)
    {
        switch (selectNum)
        {
            case 0:
                for(int i=1; i<4; i++)
                {
                    UnselectedUI[i].SetActive(true);
                }
                UnselectedUI[0].SetActive(false);
                break;
            case 1:
                UnselectedUI[0].SetActive(true);
                UnselectedUI[1].SetActive(false);
                UnselectedUI[2].SetActive(true);
                UnselectedUI[3].SetActive(true);
                break;
            case 2:
                UnselectedUI[0].SetActive(true);
                UnselectedUI[1].SetActive(true);
                UnselectedUI[2].SetActive(false);
                UnselectedUI[3].SetActive(true);
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    UnselectedUI[i].SetActive(true);
                }
                UnselectedUI[3].SetActive(false);
                break;
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

                count_UI[i].text = "x " + itemCount[i];
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

                UnselectedUI[i].SetActive(false);
                icon_UI[i].sprite = itemObj.GetComponent<Item>().itemIcon;
                name_UI[i].text = itemObj.GetComponent<Item>().itemName;
                count_UI[i].text = "x " + itemCount[i];

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
            UnselectedUI[bagNum].SetActive(true);
            icon_UI[bagNum].gameObject.SetActive(false);
            name_UI[bagNum].text = string.Empty;
            count_UI[bagNum].text = string.Empty;
            return;
        }

        objBox[bagNum, itemCount[bagNum]-1].SetActive(true);

        if(objBox[bagNum, itemCount[bagNum] - 1].CompareTag("Slime"))
        {
            objBox[bagNum, itemCount[bagNum] - 1].GetComponent<Slime>().StartSliemCoroutine();
        }

        objBox[bagNum, itemCount[bagNum] - 1].transform.position = transform.position + (transform.rotation * Vector3.forward * 3);
        objBox[bagNum, itemCount[bagNum] - 1].GetComponent<Rigidbody>().velocity = Vector3.zero;
        objBox[bagNum, itemCount[bagNum] - 1].GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward * 1500, ForceMode.Force);
        itemCount[bagNum]--;

    }
}
