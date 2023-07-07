using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] GameObject slime_object;
    AudioSource audioSource;
    [SerializeField] AudioClip[] spawnEffectclip = new AudioClip[4];

    float spawnTime = 3; //기본값 3
    [SerializeField] int limitSlimeCount = 25; //슬라임개수제한
    int currentSlimeCount = 0; //현재 생성된 슬라임의 수

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Slime_Spawn_co());
    }

    //자기 현재 위치를 기준으로 생성
    IEnumerator Slime_Spawn_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if(Random.Range(0, 2) == 0 && currentSlimeCount < limitSlimeCount) //기본값 Random.Range(0, 2) == 0
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
