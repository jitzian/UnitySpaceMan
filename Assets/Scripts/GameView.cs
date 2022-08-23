using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour {
    public TextMeshProUGUI coinsText, scoreText, maxScoreText;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.sharedInstance.currentGameState == GameState.IN_GAME) {
            Debug.Log("WE ARE IN GAMING MODE...!!!!!");
            int coins = GameManager.sharedInstance.collectedObject;
            float score = 0;
            float maxScore = 0;
            coinsText.text = coins.ToString();
            scoreText.text = "Score " + score.ToString("f1");
            maxScoreText.text = "Max Score:" + maxScore.ToString("f1");
        }
    }
}