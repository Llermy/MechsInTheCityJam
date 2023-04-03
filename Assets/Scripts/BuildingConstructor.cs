using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildingConstructor : MonoBehaviour
{
    public int numberOfFloors;
    public GameObject floorObject;
    public Material baseMaterial;
    public Material groundFloorMaterial;
    public Material roofMaterial;

    private void Start()
    {
        Construct();
    }

    private void OnValidate()
    {
        Construct();
    }

    public void Construct()
    {
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
            newFloor.GetComponent<BuildingBlock>().SetMaterial(baseMaterial);

            if(i == numberOfFloors-1)
            {
                newFloor.GetComponent<BuildingBlock>().SetMaterial(roofMaterial);
            }
            else if(i == 0)
            {
                newFloor.GetComponent<BuildingBlock>().SetMaterial(groundFloorMaterial);
            }
            else
            {
                newFloor.GetComponent<BuildingBlock>().SetMaterial(baseMaterial);
            }
        }
    }

    IEnumerator Destroy(GameObject go)
    {
        yield return new WaitForEndOfFrame();
        DestroyImmediate(go);
    }
}
