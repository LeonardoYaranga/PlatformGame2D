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

    private bool canAttack = true;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isLookingRight=true;
    private bool isCollidingWithPlayer = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        EnemyAttackBehavior();

    }


    private void EnemyAttackBehavior()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

       ////////// Debug.Log("Distance To player:" + distanceToPlayer + "isCollidingWithPlayer" + isCollidingWithPlayer);

        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            //Only x
            movement = new Vector2(direction.x, 0);
            GestionateOrientation(direction.x);
            animator.SetBool("isWalking", true);

        }
        else
        {
            movement = Vector2.zero;
            animator.SetBool("isWalking", false);

        }

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

    }

    void GestionateOrientation(float direction)
    {
        if ((isLookingRight && direction < 0) || (!isLookingRight && direction > 0))     
        {
            isLookingRight = !isLookingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
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
           //////////////////// isCollidingWithPlayer = true;

            canAttack = false;
           
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;

            GameManager.Instance.LoseHealth(damage);

            collision.gameObject.GetComponent<CharacterController>().ApplyDamageReceivedFromEnemy(forceDamage, movement);

            isCollidingWithPlayer = false;
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
