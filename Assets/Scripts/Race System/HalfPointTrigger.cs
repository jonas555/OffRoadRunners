using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject lapCompleteTrigger;
    public GameObject HalfLapTrigger;

    public GameObject myVehicle;

    void Awake()
    {
        myVehicle = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") {
            lapCompleteTrigger.SetActive(true);
            HalfLapTrigger.SetActive(false);
        }        
    }
}
