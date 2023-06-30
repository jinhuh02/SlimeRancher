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

    public int selectInvenNum = 0;

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
        selectInvenNum = selectNum;
        switch (selectNum)
        {
            case 0:
                for(int i=1; i<4; i++)
                {
                    SelectedUI[i].transform.localScale = new Vector3(1, 1, 1);
                }
                SelectedUI[0].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                break;
            case 1:
                SelectedUI[0].transform.localScale = new Vector3(1, 1, 1);
                SelectedUI[1].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                SelectedUI[2].transform.localScale = new Vector3(1, 1, 1);
                SelectedUI[3].transform.localScale = new Vector3(1, 1, 1);
                break;
            case 2:
                SelectedUI[0].transform.localScale = new Vector3(1, 1, 1);
                SelectedUI[1].transform.localScale = new Vector3(1, 1, 1);
                SelectedUI[2].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                SelectedUI[3].transform.localScale = new Vector3(1, 1, 1);
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    SelectedUI[i].transform.localScale = new Vector3(1, 1, 1);
                }
                SelectedUI[3].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                break;
        }

    }

    public void GetItem(int itemNum, GameObject itemObj)
    {
        
        for (int i=0; i<4; i++)
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


        //ù�����ε� ���� ���õǾ��ִ� ĭ�� �������� ���� �� �ִٸ�
        if (bag[selectInvenNum] == 0) //ù ����
        {
            bag[selectInvenNum] = itemNum;
            objBox[selectInvenNum, 0] = itemObj;
            objBox[selectInvenNum, 0].SetActive(false);
            itemCount[selectInvenNum]++;
            Debug.Log(itemNum + " �� " + selectInvenNum + "�� ���濡 ���� | ���� " + itemCount[selectInvenNum] + "��");

            UnselectedUI[selectInvenNum].SetActive(false);
            icon_UI[selectInvenNum].gameObject.SetActive(true);
            icon_UI[selectInvenNum].sprite = itemObj.GetComponent<Item>().itemIcon;
            name_UI[selectInvenNum].text = itemObj.GetComponent<Item>().itemName;
            count_UI[selectInvenNum].text = "x " + itemCount[selectInvenNum];

            return;
        }

        for (int i=0; i<4; i++)
        {
            if(bag[i] == 0) //ù ����
            {
                bag[i] = itemNum;
                objBox[i, 0] = itemObj;
                objBox[i, 0].SetActive(false);
                itemCount[i]++;
                Debug.Log(itemNum + " �� " + i + "�� ���濡 ���� | ���� " + itemCount[i] + "��");

                UnselectedUI[i].SetActive(false);
                icon_UI[i].gameObject.SetActive(true);
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
            bag[bagNum] = 0;
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
        

        if(itemCount[bagNum] == 0)
        {
            UnselectedUI[bagNum].SetActive(true);
            icon_UI[bagNum].gameObject.SetActive(false);
            name_UI[bagNum].text = string.Empty;
            count_UI[bagNum].text = string.Empty;
            bag[bagNum] = 0;
        }
        else
        {
            count_UI[bagNum].text = "x " + itemCount[bagNum];
        }
    }
}
