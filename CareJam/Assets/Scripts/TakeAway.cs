using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeAway : MonoBehaviour
{
    public Slider slider;
    public Text nr;
    MainCtrl ctrl;
    public bool timeSlider;

   void Start()
    {
        //ctrl = MainCtrl.gameCtrl;
        GameObject levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        if (levelManager != null)
        {
            ctrl = levelManager.GetComponent<MainCtrl>();
            if(ctrl == null)
            {
                Debug.LogError("No MainCtrl component on the level manager");
            }
        }
        else
        {
            Debug.LogError("No Level Manager in Scene! Add the Level Manager Prefab!");
        }
    }

    public void ChangeSlide(int amount)
    {
        slider.value = slider.value - amount;
        nr.text = slider.value.ToString();

        if(timeSlider)
        {
            ctrl.Time = slider.value;
        }
        else if (!timeSlider)
        {
            ctrl.Health = slider.value;
        }
    }
}
