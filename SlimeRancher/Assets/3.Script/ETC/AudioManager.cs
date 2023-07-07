using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region instance
    public static AudioManager instance = null;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] AudioSource background_Audio; //music
    [SerializeField] AudioSource effect_Audio; //���ϼҸ�, ui�Ҹ� ��
    //�������� ���� ����� �ҽ� �������� Slim, SlimeSpawner
    //�����ѵ� �������� Inventory
    //�÷��̾ �������� PlayerController

    [SerializeField] List<AudioClip> backgroundClip = new List<AudioClip>();
    [SerializeField] List<AudioClip> effectClip = new List<AudioClip>();

    private void Start()
    {
        PlayBackgroundAudio(0);
    }

    public void PlayBackgroundAudio(int clipNum)
    {
        background_Audio.clip = backgroundClip[clipNum];
        background_Audio.Play();
    }

    public void PlayEffectAudio(int clipNum)
    {
        effect_Audio.clip = effectClip[clipNum];
        effect_Audio.Play();
    }

    public void StopAudio()
    {
        if (background_Audio.isPlaying)
        {
            background_Audio.Stop();
        }

        if (effect_Audio.isPlaying)
        {
            effect_Audio.Stop();
        }
    }
}
