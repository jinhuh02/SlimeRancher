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
    public int myHP = 100;
    public int myMP = 100;

    //�ð� �� ��¥ ����
    public float currentTimeHour = 9;
    public float currentTimeSecond = 0;
    public int currentDays = 1;

    //UI�� ����������� ���콺�� �������� ī�޶� ȸ���� �ȵǵ���
    //WASD�� Shift�� �ȸ�������
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
                        //������ ��ħ�� �ȴ�
                        StartCoroutine(Morning_co());
                        break;
                    case 18:
                        //���� �ȴ�
                        StartCoroutine(Night_co());
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
