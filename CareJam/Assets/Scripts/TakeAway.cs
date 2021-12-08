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
        ctrl = MainCtrl.gameCtrl;
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
