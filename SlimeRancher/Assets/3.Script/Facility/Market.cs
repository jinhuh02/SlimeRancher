using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Item"))
        {
            Debug.Log("1�� ����! ��������!");
            Destroy(collision.gameObject);
            GameManager.instance.ComputeCoinValue(100);
        }
    }
}
