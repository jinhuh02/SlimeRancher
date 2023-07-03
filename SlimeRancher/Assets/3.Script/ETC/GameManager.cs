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
    [SerializeField] Text Time_Days;
    [SerializeField] Text Time_text;
    
    [Header("Control Value")]
    //돈관리
    public int myCoin = 0;

    //hp와 체력 관리하기
    public int myHP = 100;
    public int myMP = 100;

    //시간 및 날짜 관리
    public float currentTimeHour = 9;
    public float currentTimeSecond = 0;
    public int currentDays = 1;

    //UI가 켜져있을경우 마우스를 움직여도 카메라 회전이 안되도록
    //WASD도 Shift도 안먹히도록
    public bool isUIActivation = false;

    private Volume _postProcessVolume;
    private ColorAdjustments _colorAdjustments;

    private void Start()
    {
        _postProcessVolume = FindObjectOfType<Volume>();
        _postProcessVolume.profile.TryGet(out _colorAdjustments);
        StartCoroutine(TimeCheck_co());

        Time.timeScale = 1;
    }

    public void ComputeCoinValue(int num)
    {
        myCoin += num;
        coin_text.text = "" + myCoin;
    }

    IEnumerator TimeCheck_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            currentTimeSecond++;

            if(currentTimeSecond == 60)
            {
                currentTimeSecond = 0;
                currentTimeHour++;

                switch (currentTimeHour)
                {
                    case 4:
                        //서서히 아침이 된다
                        StartCoroutine(Morning_co());
                        break;
                    case 18:
                        //밤이 된다
                        StartCoroutine(Night_co());
                        break;
                    case 24:
                        currentTimeHour = 0;
                        currentDays++;
                        Time_Days.text = currentDays + "일 째";
                        break;
                }
            }

            if(currentTimeHour < 10)
            {
                if (currentTimeSecond < 10)
                {
                    Time_text.text = "0" + currentTimeHour + ":0" + currentTimeSecond;
                }
                else
                {
                    Time_text.text = "0" + currentTimeHour + ":" + currentTimeSecond;
                }
            }
            else
            {
                if (currentTimeSecond < 10)
                {
                    Time_text.text = currentTimeHour + ":0" + currentTimeSecond;
                }
                else
                {
                    Time_text.text = currentTimeHour + ":" + currentTimeSecond;
                }
            }
            
        }
    }

    IEnumerator Morning_co()
    {
        float rTime = 0f;
        while (true)
        {
            _colorAdjustments.postExposure.Interp(-4f, 0f, rTime);
            rTime += 0.001f;
            yield return new WaitForSeconds(0.1f);
            if (rTime > 1)
            {
                _colorAdjustments.postExposure.value = 0f;
                break;
            }
        }
    }

    IEnumerator Night_co()
    {
        float rTime = 0f;
        while (true)
        {
            _colorAdjustments.postExposure.Interp(0f, -4f, rTime);
            rTime += 0.001f;
            yield return new WaitForSeconds(0.1f);
            if (rTime > 1)
            {
                _colorAdjustments.postExposure.value = -4f;
                break;
            }
        }
    }
}
