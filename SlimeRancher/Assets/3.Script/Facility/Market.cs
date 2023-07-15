using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] plortDeposit = new AudioClip[21]; //플로트 판매

    int sountCount=0;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Item"))
        {
            //Debug.Log("1개 접수! 코인증가!");

            if(collision.transform.GetComponent<Item>().itemName.Equals("분홍색 플로트") && !collision.transform.GetComponent<Plort>().isSell)
            {
                collision.transform.GetComponent<Plort>().isSell = true;
                GameManager.instance.ComputeCoinValue(12);
                Debug.Log("접수");
            }
            else if (collision.transform.GetComponent<Item>().itemName.Equals("냥이 플로트") && !collision.transform.GetComponent<Plort>().isSell)
            {
                collision.transform.GetComponent<Plort>().isSell = true;
                GameManager.instance.ComputeCoinValue(37);
                Debug.Log("접수");
            }

            Destroy(collision.gameObject);
            
            UpsoundCount(); 
            audioSource.clip = plortDeposit[sountCount];
            audioSource.Play();
        }
    }

    private void UpsoundCount() //1초 이내에 또 판매해야 소리가 올라감
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
