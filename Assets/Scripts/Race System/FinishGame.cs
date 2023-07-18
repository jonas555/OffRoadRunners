using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    bool gameIsFinished = false;

    public GameObject finishMenuUI;   
    public Text timeLeft;   
    public Text timeText;

    public GameObject vehicle, aiVehicle;
    public GameObject vehicleController, aiController;
    public GameObject vehicleAudio, aiAudio;

    void Awake()
    {
        vehicle = GameObject.FindGameObjectWithTag("Player");
        vehicleAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<CarAudio>().gameObject;
        vehicleController = GameObject.FindGameObjectWithTag("Player").GetComponent<VC>().gameObject;

        aiVehicle = GameObject.FindGameObjectWithTag("AI");
        aiAudio = GameObject.FindGameObjectWithTag("AI").GetComponent<CarAudio>().gameObject;
        aiController = GameObject.FindGameObjectWithTag("AI").GetComponent<VC>().gameObject;
    }

    public void Finish()
    {
        //Once the game is finished, activate or disable objects
        if (gameIsFinished == false || finishMenuUI == false)
        {            
            gameIsFinished = true;
            finishMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            timeLeft.color = Color.cyan;
            timeLeft.text = timeText.GetComponent<Text>().text;
            vehicleController.SetActive(false);          
            vehicleAudio.SetActive(false);
            aiController.SetActive(false);
            aiAudio.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsFinished)
        {
            return;
        }        
    }
}
