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

    public void ChangeMaxHealth(float maxHP)
    { 
    slider.maxValue = maxHP;
        Debug.Log("Max HP: " + slider.maxValue);
    }

    public void ChangeCurrentHealth(float currentValue)
    { 
    slider.value = currentValue;
        Debug.Log("Current HP: " + slider.value);
    }

    public void InicializeHealthBar()
    {
        ChangeMaxHealth(slider.maxValue);
        ChangeCurrentHealth(slider.value);
    }


}
