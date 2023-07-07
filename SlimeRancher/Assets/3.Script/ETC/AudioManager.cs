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

    [Header("����� �ҽ�")]
    [SerializeField] AudioSource background_Audio; //music
    [SerializeField] AudioSource effect_Audio; //���ϼҸ�, ui�Ҹ� ��
    [SerializeField] AudioSource effect2_Audio; //���ϼҸ�, ui�Ҹ� ��
    //�������� ���� ����� �ҽ� �������� Slim, SlimeSpawner [�Ϸ�!!!!]
    //�����ѵ� �������� Inventory [�Ϸ�!!!!]
    //�÷��̾ �������� PlayerController [�Ϸ�!!!!]

    [Header("����� Ŭ��")]
    [SerializeField] AudioClip[] backgroundClip = new AudioClip[2]; 
    [SerializeField] AudioClip ranch_build; //�츮 ���� �� �踮�� ����
    [SerializeField] AudioClip ui_drone_activate; //ui Ȱ��ȭ
    [SerializeField] AudioClip ui_drone_exit; //ui ��Ȱ��ȭ
    [SerializeField] AudioClip[] ui_button = new AudioClip[3];
    [SerializeField] AudioClip[] inventoryChainge = new AudioClip[2];

    private void Start()
    {
        StartCoroutine(BackgroundAudio_co());
    }

    IEnumerator BackgroundAudio_co()
    {
        while (true)
        {
            switch (GameManager.instance.isnight)
            {
                case true:
                    background_Audio.clip = backgroundClip[0]; //musicRanchTheme
                    background_Audio.Play();
                    yield return new WaitForSeconds(backgroundClip[0].length); 
                    break;
                case false:
                    background_Audio.clip = backgroundClip[1]; //musicRanchThemeNight
                    background_Audio.Play();
                    yield return new WaitForSeconds(backgroundClip[1].length);
                    break;
            }
            
        }
    }

    public void Play_RanchBuild()
    {
        effect2_Audio.clip = ranch_build;
        effect2_Audio.Play();
    }

    public void Play_UI_Activate()
    {
        effect_Audio.clip = ui_drone_activate;
        effect_Audio.Play();
    }
    public void Play_UI_Exit()
    {
        effect_Audio.clip = ui_drone_exit;
        effect_Audio.Play();
    }
    public void Play_UI_Button(int num)
    {
        effect_Audio.clip = ui_button[num];
        effect_Audio.Play();
    }

    public void Play_InventoryChainge(bool isLeft)
    {
        switch (isLeft)
        {
            case true:
                effect2_Audio.clip = inventoryChainge[0];
                effect2_Audio.Play();
                break;
            case false:
                effect2_Audio.clip = inventoryChainge[1];
                effect2_Audio.Play();
                break;
        }
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
