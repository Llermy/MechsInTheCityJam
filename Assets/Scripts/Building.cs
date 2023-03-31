using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    RewardSpawner rewardSpawner;

    private void Start()
    {
        rewardSpawner = GameObject.Find("GameManager").GetComponent<RewardSpawner>();
    }

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

        rewardSpawner.DispatchTry(destroyedFloor.transform.position + new Vector3(0, destroyedFloor.height / 2, 0));
    }
}
