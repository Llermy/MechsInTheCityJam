using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public Vector2 spawnRange;
    public float minDistanceInBetween = 5;
    public float maxDistanceInBetween = 15;
    public int minNumberOfFloors = 2;
    public int maxNumberOfFloors = 10;
    public GameObject[] buildings;

    void Start()
    {
        SpawnTerrain();
    }

    public void SpawnTerrain()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        float currentLineY = -spawnRange.y;
        float currentX = -spawnRange.x + GetRandomDistance() / 2;

        while (currentLineY < spawnRange.y - minDistanceInBetween)
        {
            SpawnBuilding(new Vector3(
                currentX,
                0,
                currentLineY + GetRandomDistance() / 2
                ));

            currentX += GetRandomDistance();
            if (currentX > spawnRange.x - minDistanceInBetween)
            {
                currentX = -spawnRange.x + GetRandomDistance() / 2;
                currentLineY += GetRandomDistance();
            }
        }
    }

    public void SpawnBuilding(Vector3 position)
    {
        int buildingIndex = Random.Range(0, buildings.Length);
        int floorNumber = Random.Range(minNumberOfFloors, maxNumberOfFloors+1);
        GameObject newBuilding = Instantiate(buildings[buildingIndex], this.transform);
        newBuilding.transform.localPosition = position;
        newBuilding.GetComponent<BuildingConstructor>().numberOfFloors = floorNumber;
    }

    public float GetRandomDistance()
    {
        return Random.Range(minDistanceInBetween, maxDistanceInBetween);
    }

    public Vector2 GetRandomDistanceVector()
    {
        return new Vector2(
            Random.Range(minDistanceInBetween, maxNumberOfFloors),
            Random.Range(minDistanceInBetween, maxNumberOfFloors));
    }
}
