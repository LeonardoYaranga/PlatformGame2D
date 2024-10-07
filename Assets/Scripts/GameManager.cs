using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public HUD hud;
    public PlayerHealth playerHealth;
    public int numMaxHealths;

    private int numHealths;
    
    public int TotalPoints { get { return totalPoints; } }
    private int totalPoints;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("More than one instance of GameManager!");
        }
    }
    void Start()
    {
        numHealths = numMaxHealths;
    }

    void Update()
    {
        
    }

    public void AddPoints(int pointsToAdd)
    {
        totalPoints += pointsToAdd;
        hud.UpdatePoints(totalPoints);
       // Debug.Log(totalPoints);
    }

    public void LoseHealth(float damage)
    {
        /////**Health method with hearts**
        //numHealths--;
        //hud.DisableHealth(numHealths);

        //if (numHealths == 0)
        //{           
        //    SceneManager.LoadScene(1);
        //}
        /////**Health method with hearts**
        ///
        playerHealth.GetDamage(damage);

    }

    public bool RecoveryHealth(float heal)
    {
        /////**Health method with hearts**
        //if (numHealths != numMaxHealths)
        //{
        //    hud.ActivateHealth(numHealths);
        //    numHealths++;
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        /////**Health method with hearts**
        ///
        bool isHealthRecovered = playerHealth.Heal(heal);
        return isHealthRecovered;

    }
}
