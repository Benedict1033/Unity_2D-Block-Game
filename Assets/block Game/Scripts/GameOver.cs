using System. Collections;
using System. Collections. Generic;
using UnityEngine;
using UnityEngine. SceneManagement;
using UnityEngine. UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text secondsSurviveUI;

    bool gameOver;

    private void Start ( )
    {
        FindObjectOfType<Player> ( ). OnPlayerDeath+=OnGameOver;

    }

    private void Update ( )
    {
        if ( gameOver )
        {
            //if ( Input. GetMouseButtonDown(0))
            //{
                
            //}
        }
    }

    void OnGameOver ( )
    {
        gameOverPanel. SetActive ( true );
        //Mathf.RoundToInt  is convert float to int
        secondsSurviveUI. text=Mathf. RoundToInt ( Time.timeSinceLevelLoad ). ToString ( );
        gameOver=true;
    }


    public void restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
