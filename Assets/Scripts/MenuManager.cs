using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager sharedInstance;
    public Canvas menuCanvas;

    private void Awake() {
        if (sharedInstance == null) {
            sharedInstance = this;
        }
    }

    public void ShowMainMenu(bool show) {
        menuCanvas.enabled = show;
    }

    public void ExitGame() {
        if (EditorApplication.isPlaying) {
            EditorApplication.isPlaying = false;
        }
    }
}