using System.Collections;
using UnityEngine;

public class CurrentProgress : MonoBehaviour
{

    [SerializeField] GameObject slimeBox01;
    [SerializeField] GameObject slimeBox02;
    [SerializeField] GameObject pinkSlime;
    [SerializeField] GameObject tabbySlime;


    int days;
    int hour;
    int minute;
    int coin;
    int[] slimeCount01 = new int[2]; //0 0
    int[] slimeCount02 = new int[2];  //0 0
    int[] inventory_item = new int[4];
    int[] inventory_count = new int[4];


    public void LoadSaveData(int days, int hour, int minute, int coin, int[] slimeCount01, int[] slimeCount02, int[] inven_itme, int[] inven_count)
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
        yield return null;
        GameManager.instance.currentDays = days;
        GameManager.instance.currentTimeHour = hour;
        GameManager.instance.currentTimeMinute = minute;
        GameManager.instance.myCoin = coin;

        for(int i=0; i< slimeCount01[0]; i++)
        {
            GameObject slime = Instantiate(pinkSlime);
            slime.transform.position = slimeBox01.transform.position;
        }

        for(int i=0; i<slimeCount01[1]; i++)
        {
            GameObject slime = Instantiate(tabbySlime);
            slime.transform.position = slimeBox01.transform.position;
        }

        for (int i = 0; i < slimeCount02[0]; i++)
        {
            GameObject slime = Instantiate(pinkSlime);
            slime.transform.position = slimeBox01.transform.position;
        }

        for (int i = 0; i < slimeCount02[1]; i++)
        {
            GameObject slime = Instantiate(tabbySlime);
            slime.transform.position = slimeBox01.transform.position;
        }
    }


    //저장하고 나가시겠습니까? 에서 저장을 담당
    public SaveData UpdateSaveFileData()
    {
        SaveData saveData = new SaveData();

        saveData.days = GameManager.instance.currentDays;
        saveData.hour = (int)GameManager.instance.currentTimeHour;
        saveData.minute = (int)GameManager.instance.currentTimeMinute;
        saveData.coin = GameManager.instance.myCoin;
        saveData.slimeCount01 = slimeBox01.GetComponent<Barrier>().inSlimeCount;
        saveData.slimeCount02 = slimeBox02.GetComponent<Barrier>().inSlimeCount;
        saveData.inventory_item = inventory_item;
        saveData.inventory_count = inventory_count;


        return saveData;
    }
}