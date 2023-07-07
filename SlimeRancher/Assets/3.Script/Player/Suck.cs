using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{
    [SerializeField] GameObject vacpack;
    float pullforce = 200; //speed
    float refeshRate = 0.3f;

    Queue<Item> selectFalse = new Queue<Item>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Slime"))
        {
            StartCoroutine(Suck_co(other, true, true));
            other.GetComponent<Item>().isVacpackSelect = true;
            selectFalse.Enqueue(other.GetComponent<Item>());
            other.isTrigger = true;

            other.GetComponent<Slime>().PlayCatchAudio();

            return;
        }
        else if (other.transform.CompareTag("Food"))
        {
            StartCoroutine(Suck_co(other, true, false));
            other.GetComponent<Item>().isVacpackSelect = true;
            selectFalse.Enqueue(other.GetComponent<Item>());
            other.isTrigger = true;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            return;
        }
        else if (other.transform.CompareTag("Item"))
        {
            StartCoroutine(Suck_co(other, true, false));
            other.GetComponent<Item>().isVacpackSelect = true;
            selectFalse.Enqueue(other.GetComponent<Item>());
            other.isTrigger = true;
            return;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Slime"))
        {
            StartCoroutine(Suck_co(other, false, true));
            other.GetComponent<Item>().isVacpackSelect = false;
            other.isTrigger = false;
            return;
        }

        else if (other.transform.CompareTag("Food") || other.transform.CompareTag("Item"))
        {
            StartCoroutine(Suck_co(other, false, false));
            other.GetComponent<Item>().isVacpackSelect = false;
            other.isTrigger = false;
            return;
        }

        
    }

    IEnumerator Suck_co(Collider coll, bool shouldPull, bool isSlime)
    {

        if (shouldPull && isSlime)
        {
            //세계 공간에서 우리의 중력 기원을 정의하세요. (객체 변환 위치일 수 있음)
            Vector3 gravityOrigin = vacpack.transform.position;

            //물체에서 우리 중력 원점으로 벡터를 가져와서 정상화하세요.
            Vector3 toGravityOriginFromObject = gravityOrigin - coll.transform.position;
            toGravityOriginFromObject.Normalize();

            //부모오브젝트를 플레이어쪽으로 회전시키는데 자식오브젝트 회전값은 그대로
            //부모오브젝트가 회전한만큼 자식오브젝트는 반대로 회전시켜주면된다
            coll.transform.rotation = Quaternion.Euler(0, toGravityOriginFromObject.y, 0);
            coll.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, -toGravityOriginFromObject.y, 0);

            //벡터를 곱하면 크기가 적용하려는 힘과 같아집니다.
            float accelerationDueToGravity = 9.8f;
            toGravityOriginFromObject *= accelerationDueToGravity * pullforce * Time.deltaTime;

            //가속을 적용합니다.
            coll.GetComponent<Rigidbody>().AddForce(toGravityOriginFromObject, ForceMode.Acceleration);

            yield return refeshRate;
            StartCoroutine(Suck_co(coll, shouldPull, true));
        }
        else if (shouldPull)
        {
            //세계 공간에서 우리의 중력 기원을 정의하세요. (객체 변환 위치일 수 있음)
            Vector3 gravityOrigin = vacpack.transform.position;

            //물체에서 우리 중력 원점으로 벡터를 가져와서 정상화하세요.
            Vector3 toGravityOriginFromObject = gravityOrigin - coll.transform.position;
            toGravityOriginFromObject.Normalize();

            //부모오브젝트를 플레이어쪽으로 회전시키는데 자식오브젝트 회전값은 그대로
            //부모오브젝트가 회전한만큼 자식오브젝트는 반대로 회전시켜주면된다
            coll.transform.rotation = Quaternion.Euler(0, toGravityOriginFromObject.y, 0);

            //벡터를 곱하면 크기가 적용하려는 힘과 같아집니다.
            float accelerationDueToGravity = 9.8f;
            toGravityOriginFromObject *= accelerationDueToGravity * pullforce * Time.deltaTime;

            //가속을 적용합니다.
            coll.GetComponent<Rigidbody>().AddForce(toGravityOriginFromObject, ForceMode.Acceleration);

            yield return refeshRate;
            StartCoroutine(Suck_co(coll, shouldPull, false));
        }
        else
        {
            coll.GetComponent<Item>().isVacpackSelect = false;
        }

        coll.isTrigger = false;
    }

    private void OnDisable()
    {
        for(int i=0; i<selectFalse.Count;)
        {
            selectFalse.Dequeue().isVacpackSelect = false;
        }


    }
}
