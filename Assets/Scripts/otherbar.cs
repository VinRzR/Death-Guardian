using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class otherbar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradientvidaplayer;
    public Image fill;

    public void SetMaxPower(float power)
    {
        slider.maxValue = power;
        slider.value = power;

        fill.color = gradientvidaplayer.Evaluate(1f);

    }

    public void SetPower(float power)
    {
        slider.value = power;

        fill.color = gradientvidaplayer.Evaluate(slider.normalizedValue);
    }
}