using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLapManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;
    //public TMP_Text TrackName;
    public static string trackName;

    //delete maybe
    public static float trackTime;

    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;        

        if (sceneName == "Prototype Race")
        {
            trackName = "Circuit";
            //TrackName.GetComponent<TMP_Text>().text = "Track: " + trackName;
        } else if(sceneName == "Race Track")
        {
            trackName = "Skirmish";
            //TrackName.GetComponent<TMP_Text>().text = "Track: " + trackName;
        } else
        {
            Debug.Log("There is no scene name");
        }
    }

    // Update is called once per frame
    void Update()
    {
        MilliCount += Time.deltaTime * 10;
        trackTime += Time.deltaTime;
        MilliDisplay = MilliCount.ToString("f0");
        MilliBox.GetComponent<TMP_Text>().text = "" + MilliDisplay;

        if(MilliCount >= 9)
        {
            MilliCount = 0;
            SecondCount += 1;
        }

        if(SecondCount <= 9)
        {
            SecondBox.GetComponent<TMP_Text>().text = "0" + SecondCount + ".";
        } else
        {
            SecondBox.GetComponent<TMP_Text>().text = "" + SecondCount + ".";
        }

        if(SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

        if(MinuteCount <= 9)
        {
            MinuteBox.GetComponent<TMP_Text>().text = "0" + MinuteCount + ":";
        } else
        {
            MinuteBox.GetComponent<TMP_Text>().text = "" + MinuteCount + ":";
        }
    }
}
