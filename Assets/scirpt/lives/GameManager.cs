using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameoverUi;
    public GameObject completeLevelUI;
    public GameObject SoundGameOver;
    public GameObject SoundWin;
     void Start()
    {
        GameIsOver = false;

        Time.timeScale = 1f;
    }
    void Update()
    {
        if(WaveSpawner.win)
        {
            SoundWin.SetActive(true);
            Winlevel();
        }

        if (GameIsOver)
        {
            
            Endgame();
        }
            

        //if (Input.GetKeyDown("e"))
        //{
            //Endgame();
        //}
        if(PlayerState.Lives <= 0)
        {
            Endgame();
        }
    }
    void Endgame()
    {
        if(PlayerState.Lives <= 0)
        {
            GameIsOver = true;
            Debug.Log("Game over!");
            SoundGameOver.SetActive(true);
            gameoverUi.SetActive(true);

            Invoke("_stop", 1f);
        }
       
        
    }

    public void Menu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Winlevel()
    {
        
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

    public void _stop()
    {
        Time.timeScale = 0f;
    }
}
