using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIFinishSkirmish : MonoBehaviour
{
    public GameObject car;
    public GameObject carAI;
    public GameObject finishCamera;
    public GameObject levelMusic;
    public GameObject carAudio;
    public GameObject carAIAudio;
    public GameObject mainCamera;
    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MilliDisplay;
    public GameObject PlayerPosition;
    //public GameObject TrackName;
    public TMP_Text MinTotal;
    public TMP_Text SecTotal;
    public TMP_Text MilliTotal;
    //public TMP_Text TrackNameComplete;
    public AudioSource finishMusic;
    public GameObject finishMenuUI;
    public GameObject lapTimer;
    public GameObject pauseMenu;
    public TMP_Text PositionFinal;
    private float trackTime;

    void Awake()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        carAudio = GameObject.FindGameObjectWithTag("Player");

        carAI = GameObject.FindGameObjectWithTag("AI");
        carAIAudio = GameObject.FindGameObjectWithTag("AI");

        pauseMenu.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        //Find the object with the "TAG" and trigger it.
        if (collider.gameObject.tag == "AI")
        {
            //Disable after the trigger
            this.GetComponent<BoxCollider>().enabled = false;
            trackTime = PlayerPrefs.GetFloat("SkirmishBestTime");
            if (TimeLapManager.trackTime <= trackTime)
            {
                if (TimeLapManager.SecondCount <= 9)
                {
                    SecDisplay.GetComponent<TMP_Text>().text = "0" + TimeLapManager.SecondCount + ".";
                }
                else
                {
                    SecDisplay.GetComponent<TMP_Text>().text = "" + TimeLapManager.SecondCount + ".";
                }

                if (TimeLapManager.MinuteCount <= 9)
                {
                    MinDisplay.GetComponent<TMP_Text>().text = "0" + TimeLapManager.MinuteCount + ".";
                }
                else
                {
                    MinDisplay.GetComponent<TMP_Text>().text = "" + TimeLapManager.MinuteCount + ".";
                }

                MilliDisplay.GetComponent<TMP_Text>().text = "" + TimeLapManager.MilliCount.ToString("F0");
            }
            pauseMenu.SetActive(false);
            lapTimer.SetActive(false);
            car.SetActive(false);
            carAI.SetActive(false);
            car.GetComponent<VC>().enabled = false;
            car.GetComponent<IM>().enabled = false;
            carAI.GetComponent<VC>().enabled = false;
            carAI.GetComponent<IM>().enabled = false;
            carAudio.GetComponent<CarAudio>().enabled = false;
            carAIAudio.GetComponent<CarAudio>().enabled = false;
            car.SetActive(true);
            carAI.SetActive(true);
            finishMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MinTotal.text = MinDisplay.GetComponent<TMP_Text>().text;
            SecTotal.text = SecDisplay.GetComponent<TMP_Text>().text;
            MilliTotal.text = MilliDisplay.GetComponent<TMP_Text>().text;
            //TrackNameComplete.text = TrackName.GetComponent<TMP_Text>().text;
            PositionFinal.text = PlayerPosition.GetComponent<TMP_Text>().text;
            PlayerPrefs.SetInt("MinSave", TimeLapManager.MinuteCount);
            PlayerPrefs.SetInt("SecSave", TimeLapManager.SecondCount);
            PlayerPrefs.SetFloat("MilliSave", TimeLapManager.MilliCount);
            PlayerPrefs.SetFloat("SkirmishBestTime", TimeLapManager.trackTime);
            PlayerPrefs.SetString("SaveTrackName", TimeLapManager.trackName);
            finishCamera.SetActive(true);
            levelMusic.SetActive(false);
            mainCamera.SetActive(false);
            finishMusic.Play();
        }
    }
}
