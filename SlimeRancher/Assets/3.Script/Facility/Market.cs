using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] plortDeposit = new AudioClip[21]; //�÷�Ʈ �Ǹ�

    int sountCount=0;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Item"))
        {
            //Debug.Log("1�� ����! ��������!");

            if(collision.transform.GetComponent<Item>().itemName.Equals("��ȫ�� �÷�Ʈ") && !collision.transform.GetComponent<Plort>().isSell)
            {
                collision.transform.GetComponent<Plort>().isSell = true;
                GameManager.instance.ComputeCoinValue(12);
                Debug.Log("����");
            }
            else if (collision.transform.GetComponent<Item>().itemName.Equals("���� �÷�Ʈ") && !collision.transform.GetComponent<Plort>().isSell)
            {
                collision.transform.GetComponent<Plort>().isSell = true;
                GameManager.instance.ComputeCoinValue(37);
                Debug.Log("����");
            }

            Destroy(collision.gameObject);
            
            UpsoundCount(); 
            audioSource.clip = plortDeposit[sountCount];
            audioSource.Play();
        }
    }

    private void UpsoundCount() //1�� �̳��� �� �Ǹ��ؾ� �Ҹ��� �ö�
    {
        StopAllCoroutines();
        sountCount++;
        if(sountCount > 20)
        {
            sountCount = 0;
        }
        StartCoroutine(PlortDepositTimeCheck_co());
    }

    IEnumerator PlortDepositTimeCheck_co()
    {
        yield return new WaitForSeconds(1);
        sountCount = 0;
    }
}
