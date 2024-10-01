using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public HUD hud;

    private int numHealths=3;
    
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

    public void LoseHealth()
    {
        numHealths--;
        hud.DisableHealth(numHealths);
    }
}
