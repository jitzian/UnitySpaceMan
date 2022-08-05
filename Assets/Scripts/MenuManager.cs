using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager sharedInstance;
    public Canvas menuCanvas;

    private void Awake() {
        if (sharedInstance == null) {
            sharedInstance = this;
        }
    }

    /*public void showMainMenu() {
        menuCanvas.enabled = true;
    }

    public void hideMainMenu() {
        menuCanvas.enabled = false;
    }*/

    public void showMainMenu(bool show) {
        menuCanvas.enabled = show;
    }

    public void exitGame() {
        if (UnityEditor.EditorApplication.isPlaying) {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        
    }
}