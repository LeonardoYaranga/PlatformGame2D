using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocity;
    public float jumpForce;
    public int maxJumps;
    public LayerMask floorLayer;
    public AudioClip jumpSound;

    private Rigidbody2D rigidbody2D;
    private bool isLookingRight = true;
    private BoxCollider2D boxCollider2D;
    private int jumpsRemaining;

    private Animator animator;
    
    


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessJump();
    }

    bool isOnFloor()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, new Vector2(boxCollider2D.bounds.size.x,boxCollider2D.bounds.size.y),0f,Vector2.down,0.2f, floorLayer);
        return raycastHit2D.collider != null; 
    }

    void ProcessJump()
    {
        if (isOnFloor())
        {
            jumpsRemaining = maxJumps;
        }

        if( Input.GetKeyDown(KeyCode.Space) && jumpsRemaining>0)
        {
            jumpsRemaining--;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
            rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            AudioManager.Instance.ReproduceSound(jumpSound);
        }
    }

    void ProcessMovement()
    {
        float inputMovement = Input.GetAxis("Horizontal");

        if (inputMovement != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }


        rigidbody2D.velocity = new Vector2(inputMovement * velocity, rigidbody2D.velocity.y);

        GestionateOrientation(inputMovement);
    }

    void GestionateOrientation(float inputMovement)
    {

        if ((isLookingRight && inputMovement < 0) || (!isLookingRight && inputMovement > 0))
        {
            isLookingRight= !isLookingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }
}
