using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public enum GameState { Start, Stop,PCStart };

    [Header("References")]
    public Transform player;
    public GameObject startButton;
    public GameObject settings;
    public  GameObject restart;
    public GameObject levelCompleted;

    [Header("Game States")]
    public GameState gameState ;
    public bool isFinish;
    public float finishTime = 3.0f;

    private bool isTouch;
    private Movement movement;

    void Start()
    {
        gameState = GameState.Stop;
        movement = player.GetComponent<Movement>();

        settings.SetActive(true);
        restart.SetActive(false);
    }
    void Update()
    {
        GameOver();
        if(movement.speed <= 0)
        {
            gameState = GameState.Stop;
        }
        else
        {
            GameStart();
        }
    }

    public void GameOver()
    {
        if (isFinish && player.childCount<=3)
        {
            finishTime -= Time.deltaTime;
            if (finishTime <= 0)
            {
                levelCompleted.SetActive(true);
            }
        }        
    }
    public void GameStart()
    {
        IsTouch();

        if (isTouch)
        {
            startButton.SetActive(false);
            restart.SetActive(true);
            settings.SetActive(false);
            gameState = GameState.Start;
        }

    }

    private void IsTouch()
    {
        if (Input.touchCount > 0)
        {
            isTouch = true;
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


}
