using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCheckPoint : MonoBehaviour
{
    public int Index;
    LapCount lap;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<LapCount>())
        {
            if(lap.checkpointIndex == Index + 1 || lap.checkpointIndex == Index - 1)
            {
                lap.checkpointIndex = Index;

                Debug.Log(Index);
            }
        }
    }
}
