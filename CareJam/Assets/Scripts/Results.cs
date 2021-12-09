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
        // Det var tidigare ett logikfel att mitten alltid togs måste använda else if eller använda två checks med && (and)

        if (Time >10)
        {
            txtTime.text = YourTimeResult[0];
        }
        else if (Time >= 5)
        {
            txtTime.text = YourTimeResult[1];
        }
        else if (Time < 5)
        {
            txtTime.text = YourTimeResult[2];
        }
        else
        {
            txtTime.text = "bugg";
        }

        
        if (Health > 10)
        {
            txtHealth.text = YourHealthResult[0];
        }
        else if (Health >= 5)
        {
            txtHealth.text = YourHealthResult[1];
        }
        else if (Health < 5)
        {
            txtHealth.text = YourHealthResult[2];
        }
        else
        {
            txtTime.text = "bugg";
        }


    }

}
