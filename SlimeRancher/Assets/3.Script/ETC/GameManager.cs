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

    //돈관리
    public int myCoin = 0;

    //hp와 체력 관리하기
    public int myHP = 100;
    public int myMP = 100;

    //시간 및 날짜 관리
    public float currentTime;
    public int currentDays;

    //UI가 켜져있을경우 마우스를 움직여도 카메라 회전이 안되도록
    //WASD도 Shift도 안먹히도록
    public bool isUIActivation = false;



}
