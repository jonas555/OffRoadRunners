using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public string loadScene;

    public GameObject pauseMenuUI;
    public GameObject settingsMenu;

    //public AudioListener mainCamera;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        //Pause Menu       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();                
            }
            else
            {
                Pause();               
            }
        }
    } 

    public void Resume()
    {
        pauseMenuUI.SetActive(false);      
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {       
        Time.timeScale = 1f;
        Cursor.visible = false;
        GameIsPaused = false;
        SceneManager.LoadScene(loadScene);
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        settingsMenu.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
