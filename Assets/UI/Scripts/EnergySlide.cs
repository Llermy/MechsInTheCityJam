using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlide : MonoBehaviour
{
    public float consumeRate = 0.2f;

    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= consumeRate * Time.deltaTime;
        if(slider.value <= 0)
        {
            GameObject.Find("GameManager").GetComponent<PhaseManager>().EndGame();
        }
    }

    public void GiveBoost(float energyBoost)
    {
        slider.value += energyBoost;
    }

    public void Reset()
    {
        slider.value = 1;
    }
}
