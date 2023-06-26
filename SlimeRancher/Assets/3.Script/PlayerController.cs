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

        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * 40, ForceMode.Force);
        }


        //mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

        //GroupPlane = new Plane(Vector3.up, Vector3.zero);

        //float rayLength;

        //if (GroupPlane.Raycast(mousePosition, out rayLength))
        //{
        //    Vector3 rotate_Value = mousePosition.GetPoint(rayLength);
        //    Debug.Log(rotate_Value);

        //    //transform.LookAt -> 위에서 구한 pointTolook 위치값을 캐릭터가 바라보도록 한다
        //    //transform.LookAt(new Vector3(rotate_Value.x, transform.position.y, rotate_Value.z));
        //    if (rotate_Value.x < -300)
        //    {
        //        transform.Rotate(0, -1, 0, Space.Self);
        //    }
        //    else if (rotate_Value.x > 120)
        //    {
        //        transform.Rotate(0, 1, 0, Space.Self);
        //    }
        //}

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
