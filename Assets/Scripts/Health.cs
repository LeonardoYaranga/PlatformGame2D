using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float heal;
    private bool isHealthRecovered;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Player"))
        {
                        
           isHealthRecovered = GameManager.Instance.RecoveryHealth(heal);
          Debug.Log("Se puede recuperar vida: "+isHealthRecovered);
            if (isHealthRecovered)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
