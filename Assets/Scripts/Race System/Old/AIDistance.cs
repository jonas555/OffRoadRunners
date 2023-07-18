using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDistance : MonoBehaviour
{
    public float aiDistance;
    public GameObject[] points;
    public PositionManager master;

    void Update()
    {
        FindPosition();
    }

    public void FindPosition()
    {
        aiDistance = Vector3.Distance(points[master.currentPoint].transform.position, this.transform.position);
    }
}
