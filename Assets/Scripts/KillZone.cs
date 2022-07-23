using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    //This method is triggered when a colider is inside another one
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            PlayerController controller = collision.GetComponent<PlayerController>();
            controller.die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Outside of the dead zone");
    }
}