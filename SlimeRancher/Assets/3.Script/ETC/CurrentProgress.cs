using System.Collections;
using UnityEngine;

public class CurrentProgress : MonoBehaviour
{



    int days;
    int hour;
    int minute;
    int coin;
    int slimeCount01;
    int slimeCount02;
    int[] inventory_item = new int[4];
    int[] inventory_count = new int[4];


    public void LoadSaveData(int days, int hour, int minute, int coin, int slimeCount01, int slimeCount02, int[] inven_itme, int[] inven_count)
    {
        this.days = days;
        this.hour = hour;
        this.minute = minute;
        this.coin = coin;
        this.slimeCount01 = slimeCount01;
        this.slimeCount02 = slimeCount02;
        inventory_item = inven_itme;
        inventory_count = inven_count;

        StartCoroutine(UpdateSceneData());
    }

    IEnumerator UpdateSceneData()
    {
        yield return null;
        GameManager.instance.currentDays = days;
        GameManager.instance.currentTimeHour = hour;
        GameManager.instance.currentTimeMinute = minute;
        GameManager.instance.myCoin = coin;

    }


    //저장하고 나가시겠습니까? 에서 저장을 담당
    public SaveData UpdateSaveFileData()
    {
        SaveData saveData = new SaveData();

        saveData.days = GameManager.instance.currentDays;
        saveData.hour = (int)GameManager.instance.currentTimeHour;
        saveData.minute = (int)GameManager.instance.currentTimeMinute;
        saveData.coin = GameManager.instance.myCoin;
        saveData.slimeCount01 = slimeCount01;
        saveData.slimeCount02 = slimeCount02;
        saveData.inventory_item = inventory_item;
        saveData.inventory_count = inventory_count;


        return saveData;
    }
}