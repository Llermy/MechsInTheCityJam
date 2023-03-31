using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float spawnProbability = 0.5f;
    public GameObject rewardObject;

    public void DispatchTry(Vector3 spawnPosition)
    {
        if(Random.Range(0.0f, 1.0f) > spawnProbability)
        {
            SpawnRewardObject(spawnPosition);
        }
    }

    public void SpawnRewardObject(Vector3 spawnPosition)
    {
        Instantiate(rewardObject, spawnPosition, Quaternion.identity);
    }
}
