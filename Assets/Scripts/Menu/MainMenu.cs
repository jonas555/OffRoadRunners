using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public Canvas quitMenu;
    public Button startNewLevelText;
    public Button exitText;
    public GameObject mainMenu;
    public GameObject achievement;
    public GameObject optionsMenu;

    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startNewLevelText = startNewLevelText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
        achievement.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startNewLevelText.enabled = false;
        exitText.enabled = false;
        mainMenu.SetActive(false);
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startNewLevelText.enabled = true;
        exitText.enabled = true;
        mainMenu.SetActive(true);
    }

    public void Track01()
    {
        Time.timeScale = 1f;
        TimeLapManager.MinuteCount = 0;
        TimeLapManager.SecondCount = 0;
        TimeLapManager.MilliCount = 0;
        Cursor.lockState = CursorLockMode.Locked;
        StopMenu.GameIsPaused = false;
        SceneManager.LoadScene(2);           
    }

    public void Track02()
    {
        SceneManager.LoadScene(3);
    }

    public void AchievementMenu()
    {
        achievement.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void CloseAchievement()
    {
        achievement.SetActive(false);
    }

    public void OptionMenu()
    {
        optionsMenu.SetActive(true);
        achievement.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
