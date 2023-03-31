using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildingConstructor : MonoBehaviour
{
    public int numberOfFloors;
    public GameObject floorObject;

    //private GameObject[] floors;

    private void OnValidate()
    {
        Debug.Log("Constructing building with " + numberOfFloors + " floors.");

        BuildingBlock[] oldFloors = GetComponentsInChildren<BuildingBlock>();
        foreach(BuildingBlock curFloor in oldFloors)
        {
            StartCoroutine(Destroy(curFloor.gameObject));
        }

        float floorHeight = floorObject.GetComponent<BuildingBlock>().height;
        for(int i = 0; i < numberOfFloors; i++)
        {
            GameObject newFloor = Instantiate(floorObject, this.transform);
            newFloor.transform.localPosition = new Vector3(0, i*floorHeight, 0);
        }
    }

    IEnumerator Destroy(GameObject go)
    {
        yield return new WaitForEndOfFrame();
        DestroyImmediate(go);
    }
}
