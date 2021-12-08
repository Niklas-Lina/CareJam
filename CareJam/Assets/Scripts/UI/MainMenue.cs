using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour
{
    public GameObject creditsPanel;

    private void Start()
    {
        creditsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //Debug.Log("Return to Main Menue");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void CreditsToggle()
    {
        creditsPanel.SetActive(!creditsPanel.activeInHierarchy);
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
