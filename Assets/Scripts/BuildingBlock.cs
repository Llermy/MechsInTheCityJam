using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlock : MonoBehaviour
{
    public float height;

    [Header("Fall properties")]
    [Range(0.1f, 5f)]
    public float fallTime = 1.0f;

    [Header("Destroy properties")]
    public ParticleSystem explosionPS;
    public float explosionScale = 1.0f;

    // Make the floor fall down some distance (normally because one floor below has been destroyed)
    public void SlideDown(float distance)
    {
        float targetHeight = transform.position.y - distance;
        transform.LeanMoveY(targetHeight, fallTime).setEaseInExpo();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Projectile>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            ParticleSystem explosion = Instantiate(explosionPS, this.transform.position, Quaternion.identity);
            explosion.transform.localScale *= explosionScale;
            //explosionPS.Play();

            Building parentBuilding = GetComponentInParent<Building>();
            if(parentBuilding)
            {
                parentBuilding.OnFloorDestroy(this);
            }
        }
    }

    public void SetMaterial(Material mat)
    {
        foreach(MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>())
        {
            renderer.material = mat;
        }
    }
}
