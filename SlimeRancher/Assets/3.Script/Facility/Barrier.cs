using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    BoxCollider myCollider;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slime"))
        {
            Debug.Log("나가지마");
            other.GetComponent<Rigidbody>().velocity = -other.GetComponent<Rigidbody>().velocity * 0.9f;

        }
    }

}
