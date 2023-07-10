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
    //������
    public int myCoin = 0;

    //hp�� ü�� �����ϱ�
    [SerializeField] PlayerController playerController;
    //public int myHP = 100; //���������������
    public int myMP = 100;
    [SerializeField] Slider mp_Slider;
    [SerializeField] Text mp_Text;

    //�ð� �� ��¥ ����
    public float currentTimeHour = 9;
    public float currentTimeSecond = 0;
    public int currentDays = 1;
    public bool isnight = false;

    //UI�� ����������� ���콺�� �������� ī�޶� ȸ���� �ȵǵ���
    //WASD�� Shift�� �ȸ�������
    public bool isUIActivation = false;

    public Volume _postProcessVolume;
    private ColorAdjustments _colorAdjustments;
    public Bloom _bloom;

    private void Start()
    {
        _postProcessVolume = FindObjectOfType<Volume>();
        _postProcessVolume.profile.TryGet(out _colorAdjustments);
        _postProcessVolume.profile.TryGet(out _bloom);

        StartCoroutine(TimeCheck_co());
        ComputeCoinValue(0);

        playerController = FindObjectOfType<PlayerController>();

        Time.timeScale = 1;

    }


    public void ComputeCoinValue(int num)
    {
        myCoin += num;
        coin_text.text = "" + myCoin;
    }


    #region �ð�
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
                        //������ ��ħ�� �ȴ�
                        StartCoroutine(Morning_co());
                        isnight = false;
                        break;
                    case 18:
                        //���� �ȴ�
                        StartCoroutine(Night_co());
                        isnight = true;
                        break;
                    case 24:
                        currentTimeHour = 0;
                        currentDays++;
                        Time_Days.text = currentDays + "�� °";
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
            _colorAdjustments.postExposure.Interp(-3.5f, 0f, rTime);
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
            _colorAdjustments.postExposure.Interp(0f, -3.5f, rTime);
            rTime += 0.001f;
            yield return new WaitForSeconds(0.1f);
            if (rTime > 1)
            {
                _colorAdjustments.postExposure.value = -3.5f;
                break;
            }
        }
    }

    #endregion

    public void StartSpeedUp()
    {
        StopAllCoroutines();
        playerController.speed = 40;
        StartCoroutine(SpeedUpTimeCheck_co());
    }

    public void StopSpeedUp()
    {
        playerController.speed = 20;
        playerController.isShift = false;
        StartCoroutine(MPRecovery_co());
    }

    public bool isSpeedUp = false;

    IEnumerator SpeedUpTimeCheck_co()
    {
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
