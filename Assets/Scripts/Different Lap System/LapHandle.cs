using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapHandle : MonoBehaviour
{
    public int checkpointReached;

    public GameObject achTrigger;
    public GameObject raceFinish;

    public LapCount lap;

    public int achBronzeCode;
    public int achSilverCode;
    public int achGoldCode;

    public int carImport;

    void Awake()
    {
        achBronzeCode = PlayerPrefs.GetInt("bronze");
        achSilverCode = PlayerPrefs.GetInt("silver");
        achGoldCode = PlayerPrefs.GetInt("gold");

        carImport = CarSelection.carType;
        if (carImport == 0)
        {
            lap = GameObject.Find("Firebird_Driver").GetComponent<LapCount>();
        }
        if (carImport == 1)
        {
            lap = GameObject.Find("Miura400_Driver").GetComponent<LapCount>();
        }       
    }

    void Update()
    {
        if(lap.lapNumber == 2)
        {
            //Wins
            achBronzeCode = PlayerPrefs.GetInt("bronze");
            achSilverCode = PlayerPrefs.GetInt("silver");
            achGoldCode = PlayerPrefs.GetInt("gold");                       

            //Wins
            if (achBronzeCode != 1)
            {
                StartCoroutine(FinishLine());
            }
            if (achBronzeCode == 1 && achSilverCode != 2)
            {
                StartCoroutine(FinishLine());
            }
            if (achSilverCode == 2 && achGoldCode != 3)
            {
                StartCoroutine(FinishLine());
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        carImport = CarSelection.carType;
        if (carImport == 0 && collider.gameObject.name == "Firebird_Driver")
        {
            LapCount lap = collider.GetComponent<LapCount>();

            if(lap.checkpointIndex == checkpointReached)
            {                
                lap.checkpointIndex = 0;
                lap.lapNumber++;               
                Debug.Log("Firebird lap reached " + lap.lapNumber);
            }
        }

        if (carImport == 1 && collider.gameObject.name == "Miura400_Driver")
        {
            LapCount lap = collider.GetComponent<LapCount>();

            if (lap.checkpointIndex == checkpointReached)
            {
                lap.checkpointIndex = 0;
                lap.lapNumber++;
                Debug.Log("Miura lap reached " + lap.lapNumber);
            }
        }
    }

    IEnumerator FinishLine()
    {
        yield return new WaitForSeconds(5f);
        raceFinish.SetActive(true);
        achTrigger.SetActive(true);
    }
        
}
