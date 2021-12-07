using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeAway : MonoBehaviour
{
    public Slider slider;

    public void ChangeSlide(int amount)
    {
        slider.value = slider.value - amount;
    }
}
