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

    // Start is called before the first frame update
    void Start()
    {
        numHealths = numMaxHealths;
    }

    // Update is called once per frame
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

        //numHealths--;
        //hud.DisableHealth(numHealths);

        //if (numHealths == 0)
        //{           
        //    SceneManager.LoadScene(1);
        //}

        playerHealth.GetDamage(damage);

    }

    public bool RecoveryHealth(float heal)
    {
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

        bool isHealthRecovered = playerHealth.Heal(heal);
        return isHealthRecovered;

    }
}
