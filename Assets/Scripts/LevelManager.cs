using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager sharedInstance = null;

    public List<LevelBlock> listOfLevelBlocks = new List<LevelBlock>();
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();
    public Transform levelStartPosition;


    private void Awake() {
        if (sharedInstance == null) {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        generateInitialBlocks();
    }

    // Update is called once per frame
    void Update() {
    }

    public void addLevelBlock() {
    }

    public void removeLevelBlock() {
    }

    public void removeAllLevelBlocks() {
    }

    //Initialization
    public void generateInitialBlocks() {
        for (int i = 0; i < 3; i++) {
            addLevelBlock();
        }
    }
}