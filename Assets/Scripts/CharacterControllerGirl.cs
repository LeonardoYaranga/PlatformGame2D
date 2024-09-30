using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocity;
    public float jumpForce;

    private Rigidbody2D rigidbody2D;
    private bool isLookingRight = true;
   


    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessJump();
    }


    void ProcessJump()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
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
