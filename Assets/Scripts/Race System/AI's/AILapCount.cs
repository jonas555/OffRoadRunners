using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILapCount : MonoBehaviour
{
    public int lapNumber;
    public int checkpointIndex;

    void Start()
    {
        lapNumber = 1;
        checkpointIndex = 0;
    }
}
