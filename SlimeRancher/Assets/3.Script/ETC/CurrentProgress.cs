using System.Collections;
using UnityEngine;

public class CurrentProgress : MonoBehaviour
{

    [SerializeField] GameObject slimeBox01;
    [SerializeField] GameObject slimeBox02;
    [SerializeField] Corral corral;

    [SerializeField] GameObject pinkSlime;
    [SerializeField] GameObject tabbySlime;
    [SerializeField] GameObject carrot;
    [SerializeField] GameObject pogo;
    [SerializeField] GameObject pinkPlort;
    [SerializeField] GameObject tabbyPlort;

    Inventory inventory;

    int days;
    int hour;
    int minute;
    int coin;
    int[] slimeCount01 = new int[2]; //0 0
    int[] slimeCount02 = new int[2];  //0 0
    int[] inventory_item = new int[6];
    int[] inventory_count = new int[6];
    public bool isClearSlimeBarrier = false;
    public bool isClearExpansionBarrier = false;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void LoadSaveData(int days, int hour, int minute, int coin, int[] slimeCount01, int[] slimeCount02, int[] inven_itme, int[] inven_count, bool isClearSlimeBarrier, bool isClearExpansionBarrier)
    {
        this.days = days;
        this.hour = hour;
        this.minute = minute;
        this.coin = coin;
        this.slimeCount01 = slimeCount01;
        this.slimeCount02 = slimeCount02;
        inventory_item = inven_itme;
        inventory_count = inven_count;
        this.isClearSlimeBarrier = isClearSlimeBarrier;
        this.isClearExpansionBarrier = isClearExpansionBarrier;

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

        for(int i=0; i<4; i++)
        {
            for(int c=0; c<inventory_count[i]; c++)
            {
                switch (inventory_item[i])
                {
                    case 1: //핑크슬라임
                        GameObject itemA = Instantiate(pinkSlime);
                        itemA.GetComponent<Slime>().isSaveLoadSlime = true;
                        inventory.GetItem(1, itemA);
                        break;
                    case 2: //냥이슬라임
                        GameObject itemB = Instantiate(tabbySlime);
                        itemB.GetComponent<Slime>().isSaveLoadSlime = true;
                        inventory.GetItem(2, itemB);
                        break;
                    case 3: //당근
                        GameObject itemC = Instantiate(carrot);
                        itemC.GetComponent<Food>().isSaveLoadFood = true;
                        itemC.GetComponent<Collider>().isTrigger = false;
                        itemC.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        inventory.GetItem(3, itemC);
                        break;
                    case 4: //포고열매
                        GameObject itemD = Instantiate(pogo);
                        itemD.GetComponent<Food>().isSaveLoadFood = true;
                        itemD.GetComponent<Collider>().isTrigger = false;
                        itemD.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        inventory.GetItem(4, itemD);
                        break;
                    case 5: //핑크플로트
                        GameObject itemE = Instantiate(pinkPlort);
                        inventory.GetItem(5, itemE);
                        break;
                    case 6: //냥이플로트
                        GameObject itemF = Instantiate(tabbyPlort);
                        inventory.GetItem(6, itemF);
                        break;
                }
            }
        }

        if (isClearSlimeBarrier)
        {
            //슬라임 우리B 설치

            for (int i = 0; i < corral.barrier.Count; i++)
            {
                corral.barrier[i].SetActive(true);
            }
            corral.isLock = false;
            corral.enabled = false;
        }

        if (isClearExpansionBarrier)
        {
            //목장 확장
            FindObjectOfType<Unlock>().my_barrier.SetActive(false);
            FindObjectOfType<Unlock>().isLock = false;
            FindObjectOfType<Unlock>().enabled = false;
        }

        StartCoroutine(SlimeInstantiate_co());
    }

    IEnumerator SlimeInstantiate_co()
    {
        for (int i = 0; i < slimeCount01[0]; i++)
        {
            GameObject slime = Instantiate(pinkSlime);
            slime.GetComponent<Slime>().isSaveLoadSlime = true;
            slime.transform.position = (slimeBox01.transform.position - Vector3.down) + new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(-2.5f, 2.5f));
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
        }

        for (int i = 0; i < slimeCount01[1]; i++)
        {
            GameObject slime = Instantiate(tabbySlime);
            slime.GetComponent<Slime>().isSaveLoadSlime = true;
            slime.transform.position = (slimeBox01.transform.position - Vector3.down) + new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(-2.5f, 2.5f));
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
        }

        for (int i = 0; i < slimeCount02[0]; i++)
        {
            GameObject slime = Instantiate(pinkSlime);
            slime.GetComponent<Slime>().isSaveLoadSlime = true;
            slime.transform.position = (slimeBox02.transform.position - Vector3.down) + new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(-2.5f, 2.5f));
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
        }

        for (int i = 0; i < slimeCount02[1]; i++)
        {
            GameObject slime = Instantiate(tabbySlime);
            slime.GetComponent<Slime>().isSaveLoadSlime = true;
            slime.transform.position = (slimeBox02.transform.position - Vector3.down) + new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(-2.5f, 2.5f));
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
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
        saveData.inventory_item = inventory.bag;
        saveData.inventory_count = inventory.itemCount;
        saveData.isClearSlimeBarrier = isClearSlimeBarrier;
        saveData.isClearExpansionBarrier = isClearExpansionBarrier;

        return saveData;
    }
}