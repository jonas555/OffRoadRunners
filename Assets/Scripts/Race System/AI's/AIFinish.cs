using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIFinish : MonoBehaviour
{
    public GameObject myVehicle;
    public GameObject aiVehicle01;
    public GameObject aiVehicle02;
    public Camera mainCamera;
    public GameObject levelMusic;
    public GameObject AIlapHandler;
    //public GameObject completeTrigger;
    public AudioSource finishMusic;
    public GameObject resultsTab;
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
    public AILapCount lap1;
    public AILapCount lap2;

    void Awake()
    {
        myVehicle = GameObject.FindGameObjectWithTag("Player");
        carImport = CarSelection.carType;
        if (carImport == 0)
        {
            aiVehicle01 = GameObject.Find("Firebird_Driver_AI");
            aiVehicle02 = GameObject.Find("Firebird_Driver_AI (1)");
            lap1 = GameObject.Find("Firebird_Driver_AI").GetComponent<AILapCount>();
            lap2 = GameObject.Find("Firebird_Driver_AI (1)").GetComponent<AILapCount>();
        }
        if (carImport == 1)
        {
            aiVehicle01 = GameObject.Find("Miura400_Driver_AI");
            aiVehicle02 = GameObject.Find("Miura400_Driver_AI (1)");
            lap1 = GameObject.Find("Miura400_Driver_AI").GetComponent<AILapCount>();
            lap2 = GameObject.Find("Miura400_Driver_AI (1)").GetComponent<AILapCount>();
        }
        mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Firebird_Driver_AI" && lap1.lapNumber == 2)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            lapTimeManager.SetActive(false);
            myVehicle.SetActive(false);
            aiVehicle01.SetActive(false);
            aiVehicle02.SetActive(false);
            //completeTrigger.SetActive(false);
            AIlapHandler.SetActive(false);
            myVehicle.GetComponent<VC>().enabled = false;
            myVehicle.GetComponent<IM>().enabled = false;
            aiVehicle01.GetComponent<VC>().enabled = false;
            aiVehicle01.GetComponent<IM>().enabled = false;
            aiVehicle02.GetComponent<VC>().enabled = false;
            aiVehicle02.GetComponent<IM>().enabled = false;
            myVehicle.SetActive(true);
            aiVehicle01.SetActive(true);
            aiVehicle02.SetActive(true);
            MinTotal.text = MinDisplay.GetComponent<TMP_Text>().text;
            SecTotal.text = SecDisplay.GetComponent<TMP_Text>().text;
            MilliTotal.text = MilliDisplay.GetComponent<TMP_Text>().text;
            //TrackNameMain.text = TrackName.GetComponent<TMP_Text>().text;
            PositionFinal.text = PlayerPosition.GetComponent<TMP_Text>().text;
            PlayerPrefs.SetInt("MinSave", TimeLapManager.MinuteCount);
            PlayerPrefs.SetInt("SecSave", TimeLapManager.SecondCount);
            PlayerPrefs.SetFloat("MilliSave", TimeLapManager.MilliCount);
            PlayerPrefs.SetFloat("SaveTrackTime", TimeLapManager.trackTime);
            PlayerPrefs.SetString("SaveTrackName", TimeLapManager.trackName);
            levelMusic.SetActive(false);
            mainCamera.enabled = true;
            resultsTab.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            finishMusic.Play();
        }

        if (collider.gameObject.name == "Firebird_Driver_AI (1)" && lap2.lapNumber == 2)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            lapTimeManager.SetActive(false);
            myVehicle.SetActive(false);
            aiVehicle01.SetActive(false);
            aiVehicle02.SetActive(false);
            //completeTrigger.SetActive(false);
            AIlapHandler.SetActive(false);
            myVehicle.GetComponent<VC>().enabled = false;
            myVehicle.GetComponent<IM>().enabled = false;
            aiVehicle01.GetComponent<VC>().enabled = false;
            aiVehicle01.GetComponent<IM>().enabled = false;
            aiVehicle02.GetComponent<VC>().enabled = false;
            aiVehicle02.GetComponent<IM>().enabled = false;
            myVehicle.SetActive(true);
            aiVehicle01.SetActive(true);
            aiVehicle02.SetActive(true);
            MinTotal.text = MinDisplay.GetComponent<TMP_Text>().text;
            SecTotal.text = SecDisplay.GetComponent<TMP_Text>().text;
            MilliTotal.text = MilliDisplay.GetComponent<TMP_Text>().text;
            //TrackNameMain.text = TrackName.GetComponent<TMP_Text>().text;
            PositionFinal.text = PlayerPosition.GetComponent<TMP_Text>().text;
            PlayerPrefs.SetInt("MinSave", TimeLapManager.MinuteCount);
            PlayerPrefs.SetInt("SecSave", TimeLapManager.SecondCount);
            PlayerPrefs.SetFloat("MilliSave", TimeLapManager.MilliCount);
            PlayerPrefs.SetFloat("SaveTrackTime", TimeLapManager.trackTime);
            PlayerPrefs.SetString("SaveTrackName", TimeLapManager.trackName);
            levelMusic.SetActive(false);
            mainCamera.enabled = true;
            resultsTab.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            finishMusic.Play();
        }

        if (collider.gameObject.name == "Miura400_Driver_AI" && lap1.lapNumber == 2)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            lapTimeManager.SetActive(false);
            myVehicle.SetActive(false);
            aiVehicle01.SetActive(false);
            aiVehicle02.SetActive(false);
            //completeTrigger.SetActive(false);
            AIlapHandler.SetActive(false);
            myVehicle.GetComponent<VC>().enabled = false;
            myVehicle.GetComponent<IM>().enabled = false;
            aiVehicle01.GetComponent<VC>().enabled = false;
            aiVehicle01.GetComponent<IM>().enabled = false;
            aiVehicle02.GetComponent<VC>().enabled = false;
            aiVehicle02.GetComponent<IM>().enabled = false;
            myVehicle.SetActive(true);
            aiVehicle01.SetActive(true);
            aiVehicle02.SetActive(true);
            MinTotal.text = MinDisplay.GetComponent<TMP_Text>().text;
            SecTotal.text = SecDisplay.GetComponent<TMP_Text>().text;
            MilliTotal.text = MilliDisplay.GetComponent<TMP_Text>().text;
            //TrackNameMain.text = TrackName.GetComponent<TMP_Text>().text;
            PositionFinal.text = PlayerPosition.GetComponent<TMP_Text>().text;
            PlayerPrefs.SetInt("MinSave", TimeLapManager.MinuteCount);
            PlayerPrefs.SetInt("SecSave", TimeLapManager.SecondCount);
            PlayerPrefs.SetFloat("MilliSave", TimeLapManager.MilliCount);
            PlayerPrefs.SetFloat("SaveTrackTime", TimeLapManager.trackTime);
            PlayerPrefs.SetString("SaveTrackName", TimeLapManager.trackName);
            levelMusic.SetActive(false);
            mainCamera.enabled = true;
            resultsTab.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            finishMusic.Play();
        }

        if (collider.gameObject.name == "Miura400_Driver_AI (1)" && lap2.lapNumber == 2)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            lapTimeManager.SetActive(false);
            myVehicle.SetActive(false);
            aiVehicle01.SetActive(false);
            aiVehicle02.SetActive(false);
            //completeTrigger.SetActive(false);
            AIlapHandler.SetActive(false);
            myVehicle.GetComponent<VC>().enabled = false;
            myVehicle.GetComponent<IM>().enabled = false;
            aiVehicle01.GetComponent<VC>().enabled = false;
            aiVehicle01.GetComponent<IM>().enabled = false;
            aiVehicle02.GetComponent<VC>().enabled = false;
            aiVehicle02.GetComponent<IM>().enabled = false;
            myVehicle.SetActive(true);
            aiVehicle01.SetActive(true);
            aiVehicle02.SetActive(true);
            MinTotal.text = MinDisplay.GetComponent<TMP_Text>().text;
            SecTotal.text = SecDisplay.GetComponent<TMP_Text>().text;
            MilliTotal.text = MilliDisplay.GetComponent<TMP_Text>().text;
            //TrackNameMain.text = TrackName.GetComponent<TMP_Text>().text;
            PositionFinal.text = PlayerPosition.GetComponent<TMP_Text>().text;
            PlayerPrefs.SetInt("MinSave", TimeLapManager.MinuteCount);
            PlayerPrefs.SetInt("SecSave", TimeLapManager.SecondCount);
            PlayerPrefs.SetFloat("MilliSave", TimeLapManager.MilliCount);
            PlayerPrefs.SetFloat("SaveTrackTime", TimeLapManager.trackTime);
            PlayerPrefs.SetString("SaveTrackName", TimeLapManager.trackName);
            levelMusic.SetActive(false);
            mainCamera.enabled = true;
            resultsTab.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            finishMusic.Play();
        }
    }
}
