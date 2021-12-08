using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenue : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenueUI;

    private void Start()
    {
        ResumeGame();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Escape Button pressed");

            if(GameIsPaused)
            {
                //If paused return to game
                ResumeGame();
            }
            else
            {
                //If not paused - Pause game
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        pauseMenueUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenueUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ReturnToMainMenue()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Return to Main Menue");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }


    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
