using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhaseManager : MonoBehaviour
{
    public GameObject player;
    public GameObject freeCamera;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public GameObject gameScreen;

    public CountChanger floorCount;

    private void Start()
    {
        startScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        FreezeGame(true);
    }

    public void FreezeGame(bool freeze)
    {
        player.GetComponent<ThirdPersonMovement>().enabled = !freeze;
        player.GetComponent<ProjectileShooter>().enabled = !freeze;

        freeCamera.SetActive(!freeze);
    }

    public void EndGame()
    {
        gameOverScreen.SetActive(true);
        gameScreen.SetActive(false);
        FreezeGame(true);

        GameObject.Find("GameOverScreen/Result").GetComponent<TextMeshProUGUI>().text = floorCount.GetCount().ToString();
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        gameScreen.SetActive(true);
        FreezeGame(false);
        GameObject.Find("GameCanvas/EnergySlider").GetComponent<EnergySlide>().Reset();

        BuildingSpawner[] spawners = GameObject.FindObjectsOfType<BuildingSpawner>();
        foreach(BuildingSpawner spawner in spawners)
        {
            spawner.SpawnTerrain();
        }

        player.transform.position = Vector3.zero;
        floorCount.SetCount(0);
    }
}
