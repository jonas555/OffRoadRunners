using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLapLoad : MonoBehaviour
{
    public int minCount;
    public int secCount;
    public float milliCount;
    private string milliDisplay;
    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MilliDisplay;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Main Menu")
        {
            if (minCount < PlayerPrefs.GetInt("MinCircuitSave", 0))
            {
                minCount = PlayerPrefs.GetInt("MinCircuitSave");
                secCount = PlayerPrefs.GetInt("SecCircuitSave");
                milliCount = PlayerPrefs.GetFloat("MilliCircuitSave");

                milliDisplay = milliCount.ToString("f0");
                MilliDisplay.GetComponent<TMP_Text>().text = "0" + milliDisplay;

                if (milliCount >= 9)
                {
                    milliCount = 0;
                    secCount += 1;
                }

                if (secCount <= 9)
                {
                    SecDisplay.GetComponent<TMP_Text>().text = "0" + secCount + ".";
                }
                else
                {
                    SecDisplay.GetComponent<TMP_Text>().text = "" + secCount + ".";
                }

                if (secCount >= 60)
                {
                    secCount = 0;
                    minCount += 1;
                }

                if (minCount <= 9)
                {
                    MinDisplay.GetComponent<TMP_Text>().text = "0" + minCount + ":";
                }
                else
                {
                    MinDisplay.GetComponent<TMP_Text>().text = "" + minCount + ":";
                }
            }
        }
        else
        {
            Debug.Log("There is no scene name");
        }
    }
}
