using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{
    [SerializeField] GameObject vacpack;
    float speed = 20;

    private void OnTriggerStay(Collider other)
    {
        if (!other.transform.CompareTag("Slime"))
        {
            return;
        }

        Debug.Log(Vector3.Normalize(other.transform.position - vacpack.transform.position));
        other.transform.position -= Vector3.Normalize(other.transform.position - vacpack.transform.position) * speed * Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.CompareTag("Slime"))
        {
            return;
        }

        Debug.Log("³ª°¨");
        //other.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


}
