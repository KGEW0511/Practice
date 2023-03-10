using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fuel_Bar : MonoBehaviour
{
    public Player player;
    public Slider fuelBar;

    public Text fuelText;
    public float maxFuel;
    public float currentFuel;

    void Awake()
    {
        maxFuel = player.fuel;
    }

    void Update()
    {
        currentFuel = player.fuel;
        fuelBar.value = currentFuel / maxFuel;
        fuelText.text = string.Format("{0}%", (int)currentFuel / maxFuel * 100);
    }
}
