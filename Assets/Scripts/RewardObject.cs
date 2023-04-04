using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardObject : MonoBehaviour
{
    public float energyBoost = 0.7f;

    [Header("Animation")]
    [Range(0.01f, 5f)]
    public float rotationTime = 0.5f;
    [Range(0.01f, 100f)]
    public float moveSpeed = 5.0f;
    public Vector3 targetPositionOffset;

    private bool destroy = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.LeanRotateY(180, rotationTime).setLoopClamp();

        GameObject player = GameObject.Find("Player");
        float time = Vector3.Distance(player.transform.position, transform.position) / moveSpeed;
        transform.LeanMove(player.transform.position + targetPositionOffset, time).setEaseInCubic().setOnComplete(OnArrivePlayer);
    }

    private void Update()
    {
        if(destroy)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnArrivePlayer()
    {
        destroy = true;
        GameObject.Find("GameCanvas/EnergySlider").GetComponent<EnergySlide>().GiveBoost(energyBoost);
    }
}
