using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public bool isPassLock = false; //���� ����
    public bool isPassSilme = false; //������ �����°� ������ �����°� �ȵ�

    MeshCollider myCollider;

    private void Start()
    {
        myCollider = GetComponent<MeshCollider>();
    }

    private void OnTriggerStay(Collider other)
    {





    }



}
