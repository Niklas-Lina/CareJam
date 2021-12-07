using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public HealthSlider powerBar;
    public HealthSlider timeBar;

    public int startingPower = 1000;
    public int startingTime = 1000;

    [SerializeField] int currentPower;
    [SerializeField] int currentTime;

    private void Start()
    {
        if(powerBar != null)
        {
            powerBar.SetMaxHealth(startingPower);
        }
        if (timeBar != null)
        {
            timeBar.SetMaxHealth(startingTime);
        }

        currentPower = startingPower;
        currentTime = startingTime;

    }

    public void RemovePowerAndTime(int powerloss, int timeloss)
    {
        // update player stats
        currentTime -= timeloss;
        currentPower -= powerloss;

        if (currentTime < 0)
        {
            // ran out of time
            currentTime = 0;
        }
        if (currentPower < 0)
        {
            //ran out of power
            currentPower = 0;
        }

        // Update sliders
        powerBar.SetHealth(currentPower);
        timeBar.SetHealth(currentTime);
        
    }



}
