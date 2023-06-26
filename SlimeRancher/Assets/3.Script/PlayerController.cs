using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }
}
