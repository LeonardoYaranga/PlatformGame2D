using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangueMaxHealth(float maxHP)
    { 
    slider.maxValue = maxHP;
    }

    private void ChangeCurrentHealth(float currentValue)
    { 
    slider.value = currentValue; 
    }

    public void InicializeHealthBar()
    {
        ChangueMaxHealth(slider.maxValue);
        ChangeCurrentHealth(slider.value);
    }


}
