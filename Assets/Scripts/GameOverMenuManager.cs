using UnityEditor;
using UnityEngine;

public class GameOverMenuManager : MonoBehaviour {
    public static GameOverMenuManager sharedInstance;
    public Canvas gameOverCanvas;

    private void Awake() {
        if (sharedInstance == null) {
            sharedInstance = this;
        }
    }

    public void ShowGameOverMenu(bool showMenu) {
        gameOverCanvas.enabled = showMenu;
    }

    public void ExitGame() {
        if (EditorApplication.isPlaying) {
            EditorApplication.isPlaying = false;
        }
    }
}