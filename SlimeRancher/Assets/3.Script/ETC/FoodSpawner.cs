using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject myFood;

    [SerializeField] List<Transform> food_pos = new List<Transform>();


    //지정 위치에 음식을 생산한다
    //다 자라면 item 컴포넌트를 가진 food 오브젝트과 교체하여 플레이어가 가져갈 수 있도록 한다

    private void FixedUpdate()
    {
        



    }



}
