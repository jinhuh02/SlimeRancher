using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;

    float speed = 10;

    Vector3 mousePos;
    Vector3 worldPos;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20;
        }
        else if(speed != 10)
        {
            speed = 10;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * 40, ForceMode.Force);
        }


        mousePos = Input.mousePosition;
        worldPos = Camera.main.ScreenToViewportPoint(mousePos);
        Debug.Log(worldPos);

        if (worldPos.x < 0.3f)
        {
            transform.Rotate(0, -1, 0, Space.Self);
        }
        if (worldPos.x > 0.7f)
        {
            transform.Rotate(0, 1, 0, Space.Self);
        }
    }
}
