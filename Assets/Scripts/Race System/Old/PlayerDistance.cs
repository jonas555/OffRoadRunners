using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : MonoBehaviour
{
    public float playerDistance;
    public GameObject[] points;
    public PositionManager master;

    void Update()
    {
        FindPosition();
    }

    public void FindPosition()
    {
        playerDistance = Vector3.Distance(points[master.currentPoint].transform.position, this.transform.position);
    }
}
