using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour {
    public TextMeshProUGUI coinsText, scoreText, maxScoreText;
    private PlayerController controller;

    // Start is called before the first frame update
    void Start() {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.sharedInstance.currentGameState == GameState.IN_GAME) {
            Debug.Log("WE ARE IN GAMING MODE...!!!!!");
            var coins = GameManager.sharedInstance.collectedObject;
            var score = controller.getDistance();
            var maxScore = PlayerPrefs.GetFloat("maxScore", 0f);
            coinsText.text = coins.ToString();
            scoreText.text = "Score " + score.ToString("f1");
            maxScoreText.text = "Max Score:" + maxScore.ToString("f1");
        }
    }
}