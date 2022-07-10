using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    MENU,
    IN_GAME,
    GAME_OVER
}

public class GameManager : MonoBehaviour {

    public GameState currentGameState = GameState.MENU;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {

    }

    public void gameOver() {

    }

    public void backToMenu() {

    }

    private void setGameState(GameState gameState) {

        switch (gameState)
        {
            case GameState.MENU:
                {
                    //TODO: TBD
                    break;
                }
            case GameState.IN_GAME:
                {
                    //TODO: TBD
                    break;
                }
            case GameState.GAME_OVER:
                {
                    //TODO: TBD
                    break;
                }
        }

        this.currentGameState = gameState;

    }
}
