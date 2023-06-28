using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silme : MonoBehaviour
{
    [SerializeField] Animator slime_animator;

    private void Start()
    {
        slime_animator = transform.GetChild(0).GetComponent<Animator>();
    }
}
