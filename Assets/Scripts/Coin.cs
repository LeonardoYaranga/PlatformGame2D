using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.CompareTag("Player"))
        {
            Debug.Log("collision");
           gameManager.AddPoints(value);
            Destroy(this.gameObject);
        }
    }
}
