using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    #region instance
    public static TimeManager instance = null;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] Text Time_Days;
    [SerializeField] Text Time_text;

    //시간 및 날짜 관리
    public float currentTimeHour = 9;
    public float currentTimeMinute = 0;
    public int currentDays = 1;
    public bool isnight = false;


    private void Start()
    {
        StartCoroutine(GameStartDelay_co());
    }

    IEnumerator GameStartDelay_co()
    {
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;


        //시간 텍스트 업데이트
        Time_Days.text = currentDays + "일 째";
        if (currentTimeHour < 10)
        {
            if (currentTimeMinute < 10)
            {
                Time_text.text = "0" + currentTimeHour + ":0" + currentTimeMinute;
            }
            else
            {
                Time_text.text = "0" + currentTimeHour + ":" + currentTimeMinute;
            }
        }
        else
        {
            if (currentTimeMinute < 10)
            {
                Time_text.text = currentTimeHour + ":0" + currentTimeMinute;
            }
            else
            {
                Time_text.text = currentTimeHour + ":" + currentTimeMinute;
            }
        }

        //밤 시간일 경우 어둡게
        //if (currentTimeHour >= 18 || currentTimeHour < 4)
        //{
        //    GameManager.instance._colorAdjustments.postExposure.value = -3.5f;
        //}


        StartCoroutine(TimeCheck_co());
        GameManager.instance.ComputeCoinValue(0);
    }

    #region 시간
    IEnumerator TimeCheck_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            currentTimeMinute++;

            if (currentTimeMinute == 60)
            {
                currentTimeMinute = 0;
                currentTimeHour++;

                switch (currentTimeHour)
                {
                    case 4:
                        //서서히 아침이 된다
                        //StartCoroutine(Morning_co());
                        isnight = false;
                        break;
                    case 18:
                        //밤이 된다
                        //StartCoroutine(Night_co());
                        isnight = true;
                        break;
                    case 24:
                        currentTimeHour = 0;
                        currentDays++;
                        Time_Days.text = currentDays + "일 째";
                        break;
                }
            }

            if (currentTimeHour < 10)
            {
                if (currentTimeMinute < 10)
                {
                    Time_text.text = "0" + currentTimeHour + ":0" + currentTimeMinute;
                }
                else
                {
                    Time_text.text = "0" + currentTimeHour + ":" + currentTimeMinute;
                }
            }
            else
            {
                if (currentTimeMinute < 10)
                {
                    Time_text.text = currentTimeHour + ":0" + currentTimeMinute;
                }
                else
                {
                    Time_text.text = currentTimeHour + ":" + currentTimeMinute;
                }
            }

        }
    }

    IEnumerator Morning_co()
    {
        float rTime = 0f;
        while (true)
        {
            GameManager.instance._colorAdjustments.postExposure.Interp(-3.5f, 0f, rTime);
            rTime += 0.001f;
            yield return new WaitForSeconds(0.1f);
            if (rTime > 1)
            {
                GameManager.instance._colorAdjustments.postExposure.value = 0f;
                break;
            }
        }
    }

    IEnumerator Night_co()
    {
        float rTime = 0f;
        while (true)
        {
            GameManager.instance._colorAdjustments.postExposure.Interp(0f, -3.5f, rTime);
            rTime += 0.001f;
            yield return new WaitForSeconds(0.1f);
            if (rTime > 1)
            {
                GameManager.instance._colorAdjustments.postExposure.value = -3.5f;
                break;
            }
        }
    }

    #endregion

}
