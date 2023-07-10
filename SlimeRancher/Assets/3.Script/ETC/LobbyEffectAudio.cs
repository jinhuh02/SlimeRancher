using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyEffectAudio : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] btn_EffectAudio = new AudioClip[3];

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play_BtnEffectAudio(int type)
    {
        audioSource.clip = btn_EffectAudio[type];
        audioSource.Play();
    }
}
