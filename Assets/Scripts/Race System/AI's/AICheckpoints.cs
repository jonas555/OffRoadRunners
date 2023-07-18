using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICheckpoints : MonoBehaviour
{
    public int Index;
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
        if (carImport == 1)
        {
            lap1 = GameObject.Find("Miura400_Driver_AI").GetComponent<AILapCount>();
            lap2 = GameObject.Find("Miura400_Driver_AI (1)").GetComponent<AILapCount>();
        }           
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Firebird_Driver_AI") 
        {            
            if (lap1.checkpointIndex == Index + 1 || lap1.checkpointIndex == Index - 1)
            {
                lap1.checkpointIndex = Index;
                Debug.Log("AI01 checkpoint " + Index);
            }
        }

        if (collider.gameObject.name == "Firebird_Driver_AI (1)")
        {
            if (lap2.checkpointIndex == Index + 1 || lap2.checkpointIndex == Index - 1)
            {
                lap2.checkpointIndex = Index;
                Debug.Log("AI02 checkpoint " + Index);
            }
        }

        if (collider.gameObject.name == "Miura400_Driver_AI")
        {
            if (lap1.checkpointIndex == Index + 1 || lap1.checkpointIndex == Index - 1)
            {
                lap1.checkpointIndex = Index;
                Debug.Log("AI01 checkpoint " + Index);
            }          
        }

        if (collider.gameObject.name == "Miura400_Driver_AI (1)")
        {           
            if (lap2.checkpointIndex == Index + 1 || lap2.checkpointIndex == Index - 1)
            {
                lap2.checkpointIndex = Index;
                Debug.Log("AI02 checkpoint " + Index);
            }
        }
    }
}
