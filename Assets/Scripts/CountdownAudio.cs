using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownAudio : MonoBehaviour
{
    public GameObject CountDown;
    public AudioSource getReadyAudio;
    public AudioSource goAudio;
    public GameObject lapTimer;
    public VC vehicleController;
    public VC AIController01;
    public VC AIController02;
    public AudioSource levelMusic;
    public StopMenu pauseMenu;
    //public GameObject emoteMenu;
    public PositionController firebirdPosM;
    public PositionController miuraPosM;
    public LapCount firebirdLapCount;
    public LapCount miuraLapCount;

    public int carImport;
    public GameObject firebird;
    public GameObject miura;
    public GameObject[] AIfirebird;
    public GameObject[] AImiura;

    void Start()
    {
        carImport = CarSelection.carType;
        if(carImport == 0)
        {
            firebird.SetActive(true);            
            miura.SetActive(false);            
            vehicleController = GameObject.FindGameObjectWithTag("Player").GetComponent<VC>();
            firebirdPosM = GameObject.Find("PositionFirebirdM").GetComponent<PositionController>();
            firebirdLapCount = GameObject.FindGameObjectWithTag("Player").GetComponent<LapCount>();
            AIController01 = GameObject.Find("Firebird_Driver_AI").GetComponent<VC>();
            AIController02 = GameObject.Find("Firebird_Driver_AI (1)").GetComponent<VC>();
        }
        if (carImport == 1)
        {
            miura.SetActive(true);           
            firebird.SetActive(false);
            vehicleController = GameObject.FindGameObjectWithTag("Player").GetComponent<VC>();
            miuraPosM = GameObject.Find("PositionMiuraM").GetComponent<PositionController>();
            miuraLapCount = GameObject.FindGameObjectWithTag("Player").GetComponent<LapCount>();
            AIController01 = GameObject.Find("Miura400_Driver_AI").GetComponent<VC>();
            AIController02 = GameObject.Find("Miura400_Driver_AI (1)").GetComponent<VC>();
        }

        //miuraController = GameObject.FindGameObjectWithTag("Player").GetComponent<VC>();
        //AIFirebirdController = GameObject.FindGameObjectWithTag("AI").GetComponent<VC>();
        //AIMiuraController = GameObject.FindGameObjectWithTag("AI").GetComponent<VC>();
        pauseMenu.enabled = false;
        //emoteMenu.SetActive(false);
        StartCoroutine((CountStart()));
    }
   
    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        CountDown.GetComponent<TMP_Text>().text = "3";
        getReadyAudio.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<TMP_Text>().text = "2";
        getReadyAudio.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<TMP_Text>().text = "1";
        getReadyAudio.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        goAudio.Play();
        levelMusic.Play();
        lapTimer.SetActive(true);
        if (carImport == 0)
        {
            vehicleController.enabled = true;
            AIfirebird[0].SetActive(true);
            AIfirebird[1].SetActive(true);
            AImiura[0].SetActive(false);
            AImiura[1].SetActive(false);
            firebirdPosM.enabled = true;
            firebirdLapCount.enabled = true;
        }
        if (carImport == 1)
        {
            vehicleController.enabled = true;
            AIfirebird[0].SetActive(false);
            AIfirebird[1].SetActive(false);
            AImiura[0].SetActive(true);
            AImiura[1].SetActive(true);
            miuraPosM.enabled = true;
            miuraLapCount.enabled = true;
        }
        //miuraController.enabled = true;
        AIController01.enabled = true;
        AIController02.enabled = true;
        pauseMenu.enabled = true;
    }
}
