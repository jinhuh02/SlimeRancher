using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] GameObject slime_object;

    float spawnTime = 3;
    int limitSlimeCount = 10; //�����Ӱ�������
    int currentSlimeCount = 0; //���� ������ �������� ��

    private void Start()
    {
        StartCoroutine(Slime_Spawn_co());
    }

    //�ڱ� ���� ��ġ�� �������� ����
    IEnumerator Slime_Spawn_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if(Random.Range(0, 2) == 0 && currentSlimeCount < limitSlimeCount)
            {
                currentSlimeCount++;
                GameObject slime = Instantiate(slime_object);
                slime.transform.position = transform.position;
            }
        }
    }

}
