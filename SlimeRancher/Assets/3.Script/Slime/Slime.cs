using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] Animator slime_animator;
    [SerializeField] GameObject myPlort;

    Rigidbody slime_rigidbody;

    float power = 400;

    bool isFoodTarget = false;
    GameObject targetFood_obj;
    int step = 0;

    private float myJumpTime;

    private void Start()
    {
        slime_animator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        slime_rigidbody = GetComponent<Rigidbody>();

        myJumpTime = Random.Range(5f, 6.5f);

        slime_rigidbody.AddForce(Vector3.up * 700, ForceMode.Force);
        StartCoroutine(Slime_co());
    }

    public void StartSliemCoroutine()
    {
        StartCoroutine(Slime_co());
    }

    IEnumerator Slime_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(myJumpTime);
            switch(Random.Range(0, 10))
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

                case 5:
                    slime_rigidbody.AddForce(new Vector3(-1, 1, 0) * power, ForceMode.Force);
                    break;
                case 6:
                    slime_rigidbody.AddForce(new Vector3(0, 1, -1) * power, ForceMode.Force);
                    break;
                case 7:
                    slime_rigidbody.AddForce(new Vector3(-0.5f, 1, -0.5f) * power, ForceMode.Force);
                    break;
                case 8:
                    slime_rigidbody.AddForce(new Vector3(-0.3f, 1, -0.7f) * power, ForceMode.Force);
                    break;
                case 9:
                    slime_rigidbody.AddForce(new Vector3(-0.7f, 1, -0.3f) * power, ForceMode.Force);
                    break;
            }
        }
        


    }

    IEnumerator FindFood_co()
    {
        while (true)
        {
            if (isFoodTarget && targetFood_obj != null)
            {
                Vector3 dir = targetFood_obj.transform.position - transform.position;
                dir.Normalize();

                transform.rotation = Quaternion.Euler(0, dir.y, 0);
                transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);

                slime_rigidbody.velocity = new Vector3(dir.x, 0, dir.z) * 500 * Time.deltaTime;

                if (targetFood_obj.transform.position.y > transform.position.y+7)
                {
                    slime_rigidbody.velocity += new Vector3(0, 200, 0) * Time.deltaTime;
                }
                else
                {
                    slime_rigidbody.velocity += Vector3.down * 200 * Time.deltaTime;
                }
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Food") && !isFoodTarget && step==0)
        {
            if (collision.transform.GetComponent<Food>().isAlreadyChosen)
            {
                Debug.Log("�ٸ� �������� ���� �߰���");
                return;
            }
            //���̿� �ٰ��� �� �Դ� �ִϸ��̼� ����
            Debug.Log("���̴�!");
            collision.transform.GetComponent<Food>().isAlreadyChosen = true;
            isFoodTarget = true;
            targetFood_obj = collision.gameObject;
            step = 1;
            StopAllCoroutines();
            StartCoroutine(FindFood_co());
            return;
        }

        else if(collision.transform.CompareTag("Food") && isFoodTarget && step==1)
        {
            isFoodTarget = false;
            Debug.Log("�Ծ��");
            step = 2;
            StartCoroutine(Bite_co(collision.gameObject));
            return;
        }
    }

    IEnumerator Bite_co(GameObject food)
    {
        Debug.Log("�Ծ���");
        slime_animator.SetTrigger("bite");
        yield return new WaitForSeconds(2.5f);
        Destroy(food);
        yield return new WaitForSeconds(2f);
        //����(Plort)�� ����´�
        GameObject plort = Instantiate(myPlort);
        plort.transform.position = transform.position;
        step = 0;
        StartCoroutine(Slime_co());
    }
}
