using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silme : MonoBehaviour
{
    [SerializeField] Animator slime_animator;
    Rigidbody slime_rigidbody;

    float power = 400;

    private void Start()
    {
        slime_animator = transform.GetChild(0).GetComponent<Animator>();
        slime_rigidbody = GetComponent<Rigidbody>();

        StartCoroutine(Slime_co());
    }

    IEnumerator Slime_co()
    {
        slime_rigidbody.AddForce(Vector3.up * 700, ForceMode.Force);

        while (true)
        {
            yield return new WaitForSeconds(7);
            switch(Random.Range(0, 5))
            {
                case 0:
                    slime_rigidbody.AddForce(new Vector3(1, 1, 0) * power, ForceMode.Force);
                    break;

                case 1:
                    slime_rigidbody.AddForce(new Vector3(0, 1, 1) * power, ForceMode.Force);
                    break;
                case 2:
                    slime_rigidbody.AddForce(new Vector3(0.5f, 1, 0.5f) * power, ForceMode.Force);
                    break;

                case 3:
                    slime_rigidbody.AddForce(new Vector3(0.3f, 1, 0.7f) * power, ForceMode.Force);
                    break;
                case 4:
                    slime_rigidbody.AddForce(new Vector3(0.7f, 1, 0.3f) * power, ForceMode.Force);
                    break;
            }
        }
        


    }
}
