using UnityEngine;

public class ExitZone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Destroy previous block");
        //throw new NotImplementedException();
        if (col.tag == "Player") {
            LevelManager.sharedInstance.addLevelBlock();
            LevelManager.sharedInstance.removeLevelBlock();
        }
    }
}