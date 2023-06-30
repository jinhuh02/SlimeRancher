using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    [SerializeField] Text coin_text;
    int coin = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Item"))
        {
            Debug.Log("1�� ����! ��������!");
            Destroy(collision.gameObject);
            coin += 100;
            coin_text.text = ""+coin;
        }
    }
}
