using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] plortDeposit = new AudioClip[21]; //�÷�Ʈ �Ǹ�

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
            Debug.Log("1�� ����! ��������!");
            Destroy(collision.gameObject);
            GameManager.instance.ComputeCoinValue(100);

            //1�� �̳��� �� �Ǹ��ؾ� �Ҹ��� �ö�
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
