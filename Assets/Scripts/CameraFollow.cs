using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    //Chase any target (player, etc...)
    public Transform target;

    /**
     * x = 0.2  : For allowing to see what is ahead
     * y = 0    : To keep Y in origin
     * z = -10  : Just for testing
     */
    public Vector3 offSet = new(0.2f, 0, -10f);

    public float dampingTIme = 0.3f;
    public Vector3 cameraVelocity = Vector3.zero;

    private void Awake() {
        //What is the frame rate (60 frame per second)?
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update() {
        moveCamera(true);
    }

    public void resetCameraPosition() {
        moveCamera(false);
    }

    private void moveCamera(Boolean smooth) {
        Vector3 destination = new Vector3(
            target.position.x - offSet.x,
            offSet.y,
            offSet.z
        );

        if (smooth) {
            transform.position = Vector3.SmoothDamp(
                transform.position,
                destination,
                ref cameraVelocity,
                dampingTIme
            );
        }
        else {
            transform.position = destination;
        }
    }
}