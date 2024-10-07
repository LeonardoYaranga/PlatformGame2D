using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int attackCooldown;
    public float damage;
    public int forceDamage;


    public Transform player;
    public float detectionRadius = 5.0f;
    public float speed = 2.0f;

    private bool canAttack= true;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        EnemyAttackBehavior();
       
    }


    private void EnemyAttackBehavior()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            //Only x
            movement = new Vector2(direction.x,0);

        }
        else
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position+ movement * speed * Time.deltaTime );

    }

    //For draw the enemy detection radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!canAttack) return;

            canAttack = false;
           
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;

            GameManager.Instance.LoseHealth(damage);

            collision.gameObject.GetComponent<CharacterController>().ApplyDamageReceivedFromEnemy(forceDamage, movement);

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
