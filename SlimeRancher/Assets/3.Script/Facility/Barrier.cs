using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public bool isPassLock = false; //완전 차단
    public bool isPassSilme = false; //슬라임 들어오는건 되지만 나가는건 안됨

    MeshCollider myCollider;

    private void Start()
    {
        myCollider = GetComponent<MeshCollider>();
    }

    private void OnTriggerStay(Collider other)
    {





    }



}
