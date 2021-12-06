using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nf_test_SliderDebug_remove : MonoBehaviour
{
    public PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void DebugPlayerPower(int powerToSubtract)
    {
        playerStats.RemovePowerAndTime(powerToSubtract, 0);
    }
    public void DebugPlayerTime(int timeToSubtract)
    {
        playerStats.RemovePowerAndTime(0,timeToSubtract);
    }
}
