using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{
    [SerializeField] GameObject vacpack;
    public float pullforce = 100; //speed
    public float refeshRate = 1;

    Queue<Item> selectFalse = new Queue<Item>();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Slime"))
        {
            return;
        }

        //other.transform.position -= Vector3.Normalize(other.transform.position - vacpack.transform.position) * speed * Time.deltaTime;

        StartCoroutine(Suck_co(other, true));
        other.GetComponent<Item>().isVacpackSelect = true;
        selectFalse.Enqueue(other.GetComponent<Item>());
        other.isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.CompareTag("Slime"))
        {
            return;
        }

        //other.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

        StartCoroutine(Suck_co(other, false));
        other.GetComponent<Item>().isVacpackSelect = false;
        other.isTrigger = false;
    }

    IEnumerator Suck_co(Collider coll, bool shouldPull)
    {

        if (shouldPull)
        {
            //���� �������� �츮�� �߷� ����� �����ϼ���. (��ü ��ȯ ��ġ�� �� ����)
            Vector3 gravityOrigin = vacpack.transform.position;

            //��ü���� �츮 �߷� �������� ���͸� �����ͼ� ����ȭ�ϼ���.
            Vector3 toGravityOriginFromObject = gravityOrigin - coll.transform.position;
            toGravityOriginFromObject.Normalize();

            //�θ������Ʈ�� �÷��̾������� ȸ����Ű�µ� �ڽĿ�����Ʈ ȸ������ �״��
            //�θ������Ʈ�� ȸ���Ѹ�ŭ �ڽĿ�����Ʈ�� �ݴ�� ȸ�������ָ�ȴ�
            coll.transform.rotation = Quaternion.Euler(0, toGravityOriginFromObject.y, 0);
            coll.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, -toGravityOriginFromObject.y, 0);

            //���͸� ���ϸ� ũ�Ⱑ �����Ϸ��� ���� �������ϴ�.
            float accelerationDueToGravity = 9.8f;
            toGravityOriginFromObject *= accelerationDueToGravity * pullforce * Time.deltaTime;

            //������ �����մϴ�.
            coll.GetComponent<Rigidbody>().AddForce(toGravityOriginFromObject, ForceMode.Acceleration);

            yield return refeshRate;
            StartCoroutine(Suck_co(coll, shouldPull));
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
