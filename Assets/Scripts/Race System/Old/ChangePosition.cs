using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public bool isUsed;
    public PositionManager master;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "AI" && !isUsed || collider.tag == "Player" && !isUsed)
        {
            isUsed = true;
            master.currentPoint++;
        }
    }
}
