using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public AudioClip coinSound;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.CompareTag("Player"))
        {
           // Debug.Log("collision");
           GameManager.Instance.AddPoints(value);
           Destroy(this.gameObject);
           AudioManager.Instance.ReproduceSound(coinSound);
        }
    }
}
