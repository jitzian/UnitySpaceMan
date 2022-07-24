using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager sharedInstance = null;

    public List<LevelBlock> allTheLevelBlocks = new();
    public List<LevelBlock> currentLevelBlocks = new();
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
        var oldBlock = currentLevelBlocks[0];
        currentLevelBlocks.Remove(oldBlock);
        Destroy(oldBlock.gameObject);
    }

    public void removeAllLevelBlocks() {
        while (currentLevelBlocks.Count > 0) {
            removeLevelBlock();
        }
    }

    //Initialization
    public void generateInitialBlocks() {
        for (var i = 0; i < 3; i++) {
            addLevelBlock();
        }
    }
}