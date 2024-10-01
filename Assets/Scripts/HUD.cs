using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
  
    public TextMeshProUGUI points;
    public GameObject[] healths;


    // Update is called once per frame
    void Update()
    {
        points.text = GameManager.Instance.TotalPoints.ToString();
    }

    public void UpdatePoints( int totalPoints)
    {
        points.text =  totalPoints.ToString();
    }

    public void DisableHealth(int index)
    {
        healths[index].SetActive(false);
    }

    public void ActivateHealth(int index)
    {
        healths[index].SetActive(true);
    }

}
