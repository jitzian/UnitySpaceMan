using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Variables of the character
    public float jumpForce = 6f;
    public float runningSpeed = 2f; // m/s

    Rigidbody2D rigidBody;
    public Animator animator;
    private Vector3 startPosition;

    const string STATE_IS_ALIVE = "isAlive";
    const string STATE_IS_ON_THE_GROUND = "isOnTheGround";

    private int healthPoints { set; get; }
    private int manaPoints { set; get; }

    //Contants
    public const int INITIAL_HEALTH = 100;
    public const int INITIAL_MANA = 15;
    public const int MAX_HEALTH = 200;
    public const int MAX_MANA = 30;
    public const int MIN_HEALTH = 10;
    public const int MIN_MANA = 0;

    public LayerMask groundMask;

    private bool isLookingRight = true;

    public static PlayerController sharedInstance = null;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = this.transform.position;

        if (sharedInstance == null) {
            sharedInstance = this;
        }
    }

    // Use this for initialization
    void Start() {
        Debug.Log("Start");
        startPosition = this.transform.position;
    }

    public void startGame() {
        healthPoints = INITIAL_HEALTH;
        manaPoints = INITIAL_MANA;

        Debug.Log("startGame" + this.animator.GetBool(STATE_IS_ALIVE));
        animator.SetBool(STATE_IS_ALIVE, true);
        animator.SetBool(STATE_IS_ON_THE_GROUND, true);
        Invoke("restartPosition", 0.2f);
    }

    private void restartPosition() {
        transform.position = startPosition;
        rigidBody.velocity = Vector2.zero;

        //Reset Camera to initial position after player dies
        var mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<CameraFollow>().resetCameraPosition();
    }

    // Update is called once per frame
    void Update() {
        animator.SetBool(STATE_IS_ON_THE_GROUND, IsTouchingTheGround());

        checkInputActions();

        //Show gizmo..
        Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.red);
    }

    private void FixedUpdate() {
        if (GameManager.sharedInstance.currentGameState == GameState.IN_GAME) {
            if (rigidBody.velocity.x < runningSpeed) {
                rigidBody.velocity = new Vector2(isLookingRight ? runningSpeed : -runningSpeed, rigidBody.velocity.y);
            }
        }
        else {
            //Stop the character if we are not IN_GAME
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }

    private void checkInputActions() {
        if (Input.GetButtonDown("Jump")) {
            Debug.Log("Prepare to Jump..!!");
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            GetComponent<SpriteRenderer>().flipX = true;
            isLookingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            GetComponent<SpriteRenderer>().flipX = false;
            isLookingRight = true;
        }
    }

    void Jump() {
        if (GameManager.sharedInstance.currentGameState == GameState.IN_GAME) {
            if (IsTouchingTheGround()) {
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    //Check if player is touching the ground
    bool IsTouchingTheGround() {
        return Physics2D.Raycast(
            this.transform.position,
            Vector2.down,
            1.5f,
            groundMask
        )
            ? true
            : false;

        /*if(Physics2D.Raycast(
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
        }*/
    }

    public void die() {
        this.animator.SetBool(STATE_IS_ALIVE, false);
        GameManager.sharedInstance.gameOver();
    }

    public void collectHealth(int points) {
        if (healthPoints < MAX_HEALTH) {
            healthPoints += points;
        }
    }

    public void collectMana(int points) {
        if (manaPoints < MAX_MANA) {
            manaPoints += points;
        }
    }
}