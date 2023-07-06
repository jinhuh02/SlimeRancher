using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool isAlreadyChosen = false;

    public bool isHarvested = false;

    public FoodSpawner myFoodSpawner;

    private void OnTriggerExit(Collider other)
    {
        if (!isHarvested && other.GetComponent<FoodSpawner>())
        {
            myFoodSpawner.SpawnCountUp();
            isHarvested = true;
        }
    }

    private void OnDisable()
    {
        if (!isHarvested)
        {
            myFoodSpawner.SpawnCountUp();
            isHarvested = true;
        }
    }
}
