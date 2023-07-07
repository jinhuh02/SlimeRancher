using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] GameObject slime_object;
    AudioSource audioSource;
    [SerializeField] AudioClip[] spawnEffectclip = new AudioClip[4];

    float spawnTime = 3; //�⺻�� 3
    [SerializeField] int limitSlimeCount = 25; //�����Ӱ�������
    int currentSlimeCount = 0; //���� ������ �������� ��

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Slime_Spawn_co());
    }

    //�ڱ� ���� ��ġ�� �������� ����
    IEnumerator Slime_Spawn_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if(Random.Range(0, 2) == 0 && currentSlimeCount < limitSlimeCount) //�⺻�� Random.Range(0, 2) == 0
            {
                currentSlimeCount++;
                GameObject slime = Instantiate(slime_object);
                slime.transform.position = transform.position;
                slime.transform.rotation = Quaternion.Euler(0, 180, 0);
                audioSource.clip = spawnEffectclip[Random.Range(0, 4)];
                audioSource.Play();
            }
        }
    }

}
