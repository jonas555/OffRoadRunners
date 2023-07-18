using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishReached : MonoBehaviour
{
    public GameObject myVehicle;
    public GameObject aiVehicle01;
    public GameObject aiVehicle02;
    public Camera mainCamera;
    public GameObject levelMusic;
    public GameObject lapHandler;
    public AudioSource finishMusic;
    public GameObject pauseMenu;
    public GameObject resultsTab;
    //public AudioListener cameraListner;
    public GameObject lapTimeManager;
    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MilliDisplay;
    //public GameObject TrackName;
    public GameObject PlayerPosition;
    public TMP_Text MinTotal;
    public TMP_Text SecTotal;
    public TMP_Text MilliTotal;
    //public TMP_Text TrackNameMain;
    public TMP_Text PositionFinal;
    private float trackTime;
    public int carImport;

    void Awake()
    {
        myVehicle = GameObject.FindGameObjectWithTag("Player");
        carImport = CarSelection.carType;
        if (carImport == 0)
        {
            aiVehicle01 = GameObject.Find("Firebird_Driver_AI");
            aiVehicle02 = GameObject.Find("Firebird_Driver_AI (1)");
        }
        if (carImport == 1)
        {
            aiVehicle01 = GameObject.Find("Miura400_Driver_AI");
            aiVehicle02 = GameObject.Find("Miura400_Driver_AI (1)");
        }
        mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
        //cameraListner = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioListener>();

        pauseMenu.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            //Save the track time in this PlayerPrefs file
            /*trackTime = PlayerPrefs.GetFloat("CircuitBestTime");
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
            }*/

            lapTimeManager.SetActive(false);
            myVehicle.SetActive(false);
            aiVehicle01.SetActive(false);
            aiVehicle02.SetActive(false);
            lapHandler.SetActive(false);
            myVehicle.GetComponent<VC>().enabled = false;
            myVehicle.GetComponent<IM>().enabled = false;
            aiVehicle01.GetComponent<VC>().enabled = false;
            aiVehicle01.GetComponent<IM>().enabled = false;
            aiVehicle02.GetComponent<VC>().enabled = false;
            aiVehicle02.GetComponent<IM>().enabled = false;
            //cameraListner.enabled = false;
            myVehicle.SetActive(true);
            aiVehicle01.SetActive(true);
            aiVehicle02.SetActive(true);
            MinTotal.text = MinDisplay.GetComponent<TMP_Text>().text;
            SecTotal.text = SecDisplay.GetComponent<TMP_Text>().text;
            MilliTotal.text = MilliDisplay.GetComponent<TMP_Text>().text;
            //TrackNameMain.text = TrackName.GetComponent<TMP_Text>().text;
            PositionFinal.text = PlayerPosition.GetComponent<TMP_Text>().text;
            PlayerPrefs.SetInt("MinCircuitSave", TimeLapManager.MinuteCount);
            PlayerPrefs.SetInt("SecCircuitSave", TimeLapManager.SecondCount);
            PlayerPrefs.SetFloat("MilliCircuitSave", TimeLapManager.MilliCount);
            PlayerPrefs.SetFloat("CircuitBestTime", TimeLapManager.trackTime);
            PlayerPrefs.SetString("SaveTrackName", TimeLapManager.trackName); 
            levelMusic.SetActive(false);
            mainCamera.enabled = true;
            pauseMenu.SetActive(false);
            resultsTab.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            finishMusic.Play();
        }        
    }
}
