using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public string[] YourTimeResult;
    public string[] YourHealthResult;
    public Text txtTime;
    public Text txtHealth;

    public void SetResults(float Time, float Health)
    {
        if(Time >10)
        {
            txtTime.text = YourTimeResult[0];
        }

        if (Time > 5)
        {
            txtTime.text = YourTimeResult[1];
        }

        if (Time < 5)
        {
            txtTime.text = YourTimeResult[2];
        }


        if (Health > 10)
        {
            txtHealth.text = YourHealthResult[0];
        }


        if (Health > 5)
        {
            txtHealth.text = YourHealthResult[1];
        }


        if (Health < 5)
        {
            txtHealth.text = YourHealthResult[2];
        }

    }

}
