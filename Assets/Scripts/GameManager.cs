using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MENU,
    IN_GAME,
    GAME_OVER
}

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.MENU;

    public static GameManager sharedInstance = null;

    private PlayerController controller;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }


    // Start is called before the first frame update
    private void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.IN_GAME)
        {
            startGame();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            backToMenu();
        }
    }

    public void startGame()
    {
        setGameState(GameState.IN_GAME);
    }

    public void gameOver()
    {
        setGameState(GameState.GAME_OVER);
    }

    public void backToMenu()
    {
        setGameState(GameState.MENU);
    }

    private void setGameState(GameState gameState)
    {

        switch (gameState)
        {
            case GameState.MENU:
                {
                    //TODO: TBD
                    break;
                }
            case GameState.IN_GAME:
                {
                    controller.startGame();
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
