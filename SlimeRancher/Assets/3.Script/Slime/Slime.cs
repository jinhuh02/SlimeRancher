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

    private bool firstOnEnable = true;

    [Header("오디오 클립")]
    [SerializeField] AudioClip[] bounce = new AudioClip[4]; //튀어오를때
    [SerializeField] AudioClip bite; //먹을때
    [SerializeField] AudioClip plort; //생성할때
    [SerializeField] AudioClip[] slimevoice = new AudioClip[10]; //랜덤
    [SerializeField] AudioClip[] thrown = new AudioClip[4]; //인벤토리에서 내밷어질떄
    [SerializeField] AudioClip[] splat = new AudioClip[3];
    AudioSource audioSource;

    private void Start()
    {
        firstOnEnable = false;
        slime_animator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        slime_rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

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
            switch(Random.Range(0, 11))
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
                case 10:
                    audioSource.clip = slimevoice[Random.Range(0, 10)];
                    audioSource.Play();
                    continue;
            }
            audioSource.clip = bounce[Random.Range(0, 4)];
            audioSource.Play();
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
                Debug.Log("다른 슬라임이 먼저 발견함");
                return;
            }
            //먹이에 다가간 후 먹는 애니메이션 진행
            Debug.Log("먹이다!");
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
            Debug.Log("먹어볼게");
            step = 2;
            StartCoroutine(Bite_co(collision.gameObject));
            return;
        }

        else if (collision.gameObject.layer == 6)
        {
            audioSource.clip = splat[Random.Range(0, 3)];
            audioSource.Play();
        }
    }

    IEnumerator Bite_co(GameObject food)
    {
        Debug.Log("먹었다");
        slime_animator.SetTrigger("bite");
        yield return new WaitForSeconds(2.5f);
        Destroy(food);
        audioSource.clip = bite;
        audioSource.Play();

        yield return new WaitForSeconds(2f);
        //보석(Plort)를 내뱉는다
        GameObject plort = Instantiate(myPlort);
        plort.transform.position = transform.position;
        step = 0;

        audioSource.clip = this.plort;
        audioSource.Play();

        StartCoroutine(Slime_co());
    }


    public void PlayCatchAudio()
    {
        audioSource.clip = thrown[Random.Range(0, 4)];
        audioSource.Play();
    }


    private void OnEnable()
    {
        if (!firstOnEnable)
        {
            audioSource.clip = thrown[Random.Range(0, 4)];
            audioSource.Play();
        }
    }
}
