using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance = null;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //������
    public int myCoin = 0;

    //hp�� ü�� �����ϱ�
    public int myHP = 100;
    public int myMP = 100;

    //�ð� �� ��¥ ����
    public float currentTime;
    public int currentDays;

    //UI�� ����������� ���콺�� �������� ī�޶� ȸ���� �ȵǵ���
    //WASD�� Shift�� �ȸ�������
    public bool isUIActivation = false;



}
