using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    // --------------------------------------------------------------

    
    [SerializeField]
    Text ScoreText;
    [SerializeField]
    Text GameOver;
    private static bool gameOver = false;

    // --------------------------------------------------------------

    int score = 0;

    // --------------------------------------------------------------

    public static void finishGame(){
        gameOver = true;
    }

    void Update(){
        if (Input.GetKeyDown("r")){
            Application.LoadLevel (Application.loadedLevel);
            gameOver = false;

        }
        if (gameOver){
            GameOver.text = "Congratulations! You have finished the game. Press 'r' for Restart";
        }
    }

    void OnEnable()
    {
        DeathTrigger.OnPlayerDeath += OnUpdateScore;
    }

    void OnDisable()
    {
        DeathTrigger.OnPlayerDeath -= OnUpdateScore;
    }

    void OnUpdateScore(int playerNum)
    {
        score += 1;
        ScoreText.text = "Deaths: " + score;    
    }
}
