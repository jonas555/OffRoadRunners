using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PosUp : MonoBehaviour
{
    public GameObject positionDisplay;

    void Start()
    {
        positionDisplay = GameObject.Find("UIRace/Position");
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "CarPos")
        {
            positionDisplay.GetComponent<TMP_Text>().text = "1st Place";
        }
    }
}
