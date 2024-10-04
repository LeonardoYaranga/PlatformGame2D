using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int attackCooldown;
    public float damage;

    private bool canAttack= true;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!canAttack) return;

            canAttack = false;
           
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;

            GameManager.Instance.LoseHealth(damage);

            other.gameObject.GetComponent<CharacterController>().ApplyDamageReceivedFromEnemy();

            Invoke("ReactivateAttack", attackCooldown);

        }
    }

    void ReactivateAttack()
    {
        canAttack = true;

        Color color = spriteRenderer.color;
        color.a = 1f;
        spriteRenderer.color = color;
    }

}
