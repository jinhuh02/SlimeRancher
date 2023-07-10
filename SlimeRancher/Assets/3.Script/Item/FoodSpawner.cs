using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject myFood;

    [SerializeField] List<GameObject> food_pos = new List<GameObject>();
    [SerializeField] float maxScale = 0;

    public int spawnCount = 0;

    List<GameObject> undergrownFood = new List<GameObject>(); 

    //지정 위치에 음식을 생산한다
    //다 자라면 item 컴포넌트를 가진 food 오브젝트과 교체하여 플레이어가 가져갈 수 있도록 한다

    public void SpawnCountUp()
    {
        spawnCount++;

        if (spawnCount == food_pos.Count && gameObject.activeInHierarchy)
        {
            spawnCount = 0;
            StartCoroutine(CreationFood_co());
        }
    }

    IEnumerator CreationFood_co()
    {
        //Debug.Log("농작물을 다시 생성합니다");

        yield return new WaitForSeconds(1);
        for(int i=0; i<food_pos.Count; i++)
        {
            //GameObject food = Instantiate(myFood);
            //undergrownFood.Add(food);
            //undergrownFood[i].GetComponent<Item>().enabled = false;
            //undergrownFood[i].transform.SetParent(gameObject.transform.parent);
            //undergrownFood[i].transform.position = food_pos[i].transform.position;
            //undergrownFood[i].transform.localScale = new Vector3(maxScale * 0.2f, maxScale * 0.2f, maxScale * 0.2f);
            food_pos[i].SetActive(true);
            food_pos[i].transform.localScale = new Vector3(maxScale * 0.2f, maxScale * 0.2f, maxScale * 0.2f);
        }

        yield return new WaitForSeconds(3);

        for(int i=0; i<food_pos.Count; i++)
        {
            //undergrownFood[i].transform.localScale = new Vector3(maxScale * 0.5f, maxScale * 0.5f, maxScale * 0.5f);
            food_pos[i].transform.localScale = new Vector3(maxScale * 0.5f, maxScale * 0.5f, maxScale * 0.5f);
        }

        yield return new WaitForSeconds(3);

        for (int i = 0; i < food_pos.Count; i++)
        {
            //undergrownFood[i].transform.localScale = new Vector3(maxScale * 0.8f, maxScale * 0.8f, maxScale * 0.8f);
            food_pos[i].transform.localScale = new Vector3(maxScale * 0.8f, maxScale * 0.8f, maxScale * 0.8f);
        }

        yield return new WaitForSeconds(3);

        for (int i = 0; i < food_pos.Count; i++)
        {
            food_pos[i].SetActive(false);

            GameObject food = Instantiate(myFood);
            food.transform.SetParent(gameObject.transform.parent);
            food.transform.position = food_pos[i].transform.position;
            food.GetComponent<Food>().myFoodSpawner = this;
        }

        //undergrownFood.Clear();
        //Debug.Log("농작물을 수확할 수 있습니다");
    }

}
