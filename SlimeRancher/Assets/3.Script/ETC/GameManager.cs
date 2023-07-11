using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance = null;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("UI")]
    [SerializeField] Text coin_text;
    
    [Header("Control Value")]
    //돈관리
    public int myCoin = 0;

    //hp와 체력 관리하기
    [SerializeField] PlayerController playerController;
    //public int myHP = 100; //사용하지않을거임
    public int myMP = 100;
    [SerializeField] Slider mp_Slider;
    [SerializeField] Text mp_Text;

    

    //UI가 켜져있을경우 마우스를 움직여도 카메라 회전이 안되도록
    //WASD도 Shift도 안먹히도록
    public bool isUIActivation = false;


    public Volume _postProcessVolume;
    public ColorAdjustments _colorAdjustments;
    public Bloom _bloom;

    private void Start()
    {
        _postProcessVolume = FindObjectOfType<Volume>();
        _postProcessVolume.profile.TryGet(out _colorAdjustments);
        _postProcessVolume.profile.TryGet(out _bloom);

        playerController = FindObjectOfType<PlayerController>();

        Time.timeScale = 1;

    }


    public void ComputeCoinValue(int num)
    {
        myCoin += num;
        coin_text.text = "" + myCoin;
    }



    public void StartSpeedUp()
    {
        StopAllCoroutines();
        StartCoroutine(SpeedUpTimeCheck_co());
    }

    public void StopSpeedUp()
    {
        StopAllCoroutines();
        playerController.speed = 20;
        playerController.isShift = false;
        StartCoroutine(MPRecovery_co());
    }

    public bool isSpeedUp = false;

    IEnumerator SpeedUpTimeCheck_co()
    {
        if (myMP > 0)
        {
            playerController.speed = 40;
        }

        while (true)
        {
            yield return new WaitForSeconds(0.07f);

            if (myMP <= 0)
            {
                myMP = 0;
                mp_Text.text = myMP.ToString();
                mp_Slider.value = myMP;
                StopSpeedUp();
                yield break;
            }
            else if (!isSpeedUp)
            {
                mp_Text.text = myMP.ToString();
                mp_Slider.value = myMP;
                StopSpeedUp();
                yield break;
            }

            myMP--;
            mp_Text.text = myMP.ToString();
            mp_Slider.value = myMP;
        }
    }

    IEnumerator MPRecovery_co()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            myMP++;
            mp_Text.text = myMP.ToString();
            mp_Slider.value = myMP;
            if (myMP >= 100)
            {
                myMP = 100;
                mp_Text.text = myMP.ToString();
                mp_Slider.value = myMP;
                yield break;
            }
        }
    }

}
