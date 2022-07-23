using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager sharedInstance = null;

    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
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
        int randomIdx = Random.Range(0, allTheLevelBlocks.Count);

        LevelBlock block;
        //Where to position the block
        Vector3 spawnPosition = Vector3.zero;

        if (currentLevelBlocks.Count == 0) {
            block = Instantiate(allTheLevelBlocks[0]);
            spawnPosition = levelStartPosition.position;
        }
        else {
            block = Instantiate(allTheLevelBlocks[randomIdx]);
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }

        block.transform.SetParent(transform, false);

        //Correction of vector
        Vector3 correction = new Vector3(
            spawnPosition.x - block.startPoint.position.x,
            spawnPosition.y - block.startPoint.position.y,
            0
        );
        block.transform.position = correction;

        currentLevelBlocks.Add(block);
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