using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables of the character
    public float jumpForce = 9f;
    Rigidbody2D rigidBody;
    public Animator animator;

    const string STATE_IS_ALIVE = "isAlive";
    const string STATE_IS_ON_THE_GROUND = "isOnTheGround";

    public LayerMask groundMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        animator.SetBool(STATE_IS_ALIVE, true);
        animator.SetBool(STATE_IS_ON_THE_GROUND, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Prepare to Jump..!!");
            Jump();
        }
        animator.SetBool(STATE_IS_ON_THE_GROUND, IsTouchingTheGround());

        //Show gizmo..
        Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.red);
    }

    void Jump()
    {
        if (IsTouchingTheGround())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
    }

    //Check if player is touching the ground
    bool IsTouchingTheGround()
    {

        /*return Physics2D.Raycast(
            this.transform.position,
            Vector2.down,
            1.5f,
            groundMask
        ) ? true : false;*/

        if(Physics2D.Raycast(
                        this.transform.position,
                        Vector2.down,
                        1.5f,
                        groundMask
                    )
            )
        {
            //animator.enabled = true;
            return true;
        }
        else
        {
            //animator.enabled = false;
            return false;
        }

    }

}
