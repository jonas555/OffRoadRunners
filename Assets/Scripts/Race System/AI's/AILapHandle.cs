using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILapHandle : MonoBehaviour
{
    public int checkpointReached;
    
    public GameObject raceFinish01;
    public GameObject raceFinish02;

    public AILapCount lap1;
    public AILapCount lap2;
    public int carImport;

    void Start()
    {
        carImport = CarSelection.carType;
        if (carImport == 0)
        {
            lap1 = GameObject.Find("Firebird_Driver_AI").GetComponent<AILapCount>();
            lap2 = GameObject.Find("Firebird_Driver_AI (1)").GetComponent<AILapCount>();
        }
        if(carImport == 1)
        {
            lap1 = GameObject.Find("Miura400_Driver_AI").GetComponent<AILapCount>();
            lap2 = GameObject.Find("Miura400_Driver_AI (1)").GetComponent<AILapCount>();
        }           
    }

    void Update()
    {
        if (lap1.lapNumber == 2)
        {
            StartCoroutine(FinishLine01());
        }

        if (lap2.lapNumber == 2)
        {
            StartCoroutine(FinishLine02());
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Firebird_Driver_AI")
        {
            if (lap1.checkpointIndex == checkpointReached)
            {
                lap1.checkpointIndex = 0;
                lap1.lapNumber++;
                Debug.Log("AI01 lap reached " + lap1.lapNumber);
            }           
        }

        if (collider.gameObject.name == "Firebird_Driver_AI (1)")
        {
            if (lap2.checkpointIndex == checkpointReached)
            {
                lap2.checkpointIndex = 0;
                lap2.lapNumber++;
                Debug.Log("AI02 lap reached " + lap2.lapNumber);
            }
        }

        if (collider.gameObject.name == "Miura400_Driver_AI")
        {
           if (lap1.checkpointIndex == checkpointReached)
           {
                lap1.checkpointIndex = 0;
                lap1.lapNumber++;
                Debug.Log("AI01 lap reached " + lap1.lapNumber);
           }                             
        }

        if (collider.gameObject.name == "Miura400_Driver_AI (1)")
        {
           if (lap2.checkpointIndex == checkpointReached)
           {
                lap2.checkpointIndex = 0;
                lap2.lapNumber++;
                Debug.Log("AI02 lap reached " + lap2.lapNumber);
           }
        }
    }

    IEnumerator FinishLine01()
    {
        yield return new WaitForSeconds(5f);
        raceFinish01.SetActive(true);
    }

    IEnumerator FinishLine02()
    {
        yield return new WaitForSeconds(5f);
        raceFinish02.SetActive(true);
    }
}
