using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public void OnFloorDestroy(BuildingBlock destroyedFloor)
    {
        float currentHeight = transform.position.y;
        BuildingBlock[] floors = GetComponentsInChildren<BuildingBlock>();
        for(int i = 0; i < floors.Length; i++)
        {
            if (floors[i] == destroyedFloor)
                continue;

            if(floors[i].transform.position.y > currentHeight)
            {
                floors[i].SlideDown(floors[i].transform.position.y - currentHeight);
            }
            currentHeight += floors[i].height;
        }
    }
}
