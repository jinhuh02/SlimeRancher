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
            StartCoroutine(Suck_co(coll, shouldPull, true));
        }
        else if (shouldPull)
        {
            //���� �������� �츮�� �߷� ����� �����ϼ���. (��ü ��ȯ ��ġ�� �� ����)
            Vector3 gravityOrigin = vacpack.transform.position;

            //��ü���� �츮 �߷� �������� ���͸� �����ͼ� ����ȭ�ϼ���.
            Vector3 toGravityOriginFromObject = gravityOrigin - coll.transform.position;
            toGravityOriginFromObject.Normalize();

            //�θ������Ʈ�� �÷��̾������� ȸ����Ű�µ� �ڽĿ�����Ʈ ȸ������ �״��
            //�θ������Ʈ�� ȸ���Ѹ�ŭ �ڽĿ�����Ʈ�� �ݴ�� ȸ�������ָ�ȴ�
            coll.transform.rotation = Quaternion.Euler(0, toGravityOriginFromObject.y, 0);

            //���͸� ���ϸ� ũ�Ⱑ �����Ϸ��� ���� �������ϴ�.
            float accelerationDueToGravity = 9.8f;
            toGravityOriginFromObject *= accelerationDueToGravity * pullforce * Time.deltaTime;

            //������ �����մϴ�.
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
