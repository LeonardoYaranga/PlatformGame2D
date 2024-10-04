using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.ChangeMaxHealth(health);
        healthBar.ChangeCurrentHealth(health);
        //healthBar.InicializeHealthBar();
    }

    public void GetDamage(float damage)
    {
        Debug.Log("damage: "+ damage);
        health -= damage;
        healthBar.ChangeCurrentHealth(health);
        if(health <= 0)
        {
            Destroy(gameObject);
            //    SceneManager.LoadScene(1);

        }
    }

    public bool Heal(float heal)
    {
        bool wasHealed;
        if (health == maxHealth)
        {
            wasHealed = false;
        }
        else if ((health + heal) > maxHealth)
        {
            health = maxHealth;
            wasHealed = true;
        }
        else
        {
            health += heal;
            wasHealed = true;
        }

        healthBar.ChangeCurrentHealth(health);
        return wasHealed;

    }

}
