using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] plortDeposit = new AudioClip[21]; //플로트 판매

    int sountCount=0;
    bool isInOneSecond = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Item"))
        {
            Debug.Log("1개 접수! 코인증가!");
            Destroy(collision.gameObject);
            GameManager.instance.ComputeCoinValue(100);

            //1초 이내에 또 판매해야 소리가 올라감
            UpsoundCount();
            audioSource.clip = plortDeposit[sountCount];
            audioSource.Play();
        }
    }

    private void UpsoundCount()
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
