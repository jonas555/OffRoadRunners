using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AISLapComplete : MonoBehaviour
{
    public GameObject LapAICompleteTrigger;
    public GameObject HalfLapAITrigger;

    public GameObject aiVehicle;

    //public GameObject lapAICounter;
    public int lapsAIChecked;
   
    public GameObject raceAIFinish;

    void Awake()
    {
        aiVehicle = GameObject.FindGameObjectWithTag("AI");
    }

    void Update()
    {
        //Player Lap Count
        if (lapsAIChecked == 2)
        {
            raceAIFinish.SetActive(true);
            LapAICompleteTrigger.SetActive(false);            
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //AI Lap Count Trigger
        if (collider.gameObject.tag == "AI")
        {
            lapsAIChecked += 1;

            //lapAICounter.GetComponent<TMP_Text>().text = "" + lapsAIChecked;
            Debug.Log(lapsAIChecked);
            HalfLapAITrigger.SetActive(true);
            LapAICompleteTrigger.SetActive(false);           
        }
    }
}
