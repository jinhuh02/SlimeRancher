using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] GameObject slime_object;

    [SerializeField] float spawnTime = 3;

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
            if(Random.Range(0, 2) == 0)
            {
                GameObject slime = Instantiate(slime_object);
                slime.transform.position = transform.position;
            }
        }
    }

}
