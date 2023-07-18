using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapCount : MonoBehaviour
{
    public int lapNumber;
    public int checkpointIndex;

    public TMP_Text lapText;

    //public int carImport;

    void Start()
    {
        lapNumber = 1;
        checkpointIndex = 0;
        lapText = GameObject.Find("UIRace/Lap Panel/Laps/Lap Count").GetComponent<TMP_Text>();
    }

    void Update()
    {
        lapText.GetComponent<TMP_Text>().text = "" + lapNumber;
    }
}
