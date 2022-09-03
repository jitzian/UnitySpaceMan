using UnityEngine;

public class Enemy : MonoBehaviour {
    public float runningSpeed = 1.5f;

    public int enemyDamage = 10;

    public Rigidbody2D rigidBody;

    public bool facingRight;

    private Vector3 startPosition;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Use this for initialization
    void Start() {
        transform.position = startPosition;
    }

    private void FixedUpdate() {
        var currentRunningSpeed = runningSpeed;

        if (facingRight) {
            //Mirando hacia la derecha
            currentRunningSpeed = runningSpeed;
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else {
            //Mirando hacia la izquierda
            currentRunningSpeed = -runningSpeed;
            this.transform.eulerAngles = Vector3.zero;
        }

        if (GameManager.sharedInstance.currentGameState == GameState.IN_GAME) {
            rigidBody.velocity = new Vector2(currentRunningSpeed,
                rigidBody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("OnTriggerEnter2D" + collision.tag);
        switch (collision.tag) {
            case "Coin":
                return;
            case "Player":
                collision.gameObject.GetComponent<PlayerController>().collectHealth(-enemyDamage);
                return;
            default:
                //Si llegamos aquí, no hemos chocado ni con monedas, ni con players
                //Lo más normal es que aquí haya otro enemigo o bien escenario
                //Vamos a hacer que el enemigo rote
                facingRight = !facingRight;
                break;
        }
    }
}