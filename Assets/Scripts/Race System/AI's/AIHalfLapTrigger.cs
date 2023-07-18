using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHalfLapTrigger : MonoBehaviour
{
    public GameObject lapAICompleteTrigger;
    public GameObject HalfLapAITrigger;

    public GameObject aiVehicle;

    void Awake()
    {
        aiVehicle = GameObject.FindGameObjectWithTag("AI");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "AI")
        {
            lapAICompleteTrigger.SetActive(true);
            HalfLapAITrigger.SetActive(false);
        }
    }
}
