using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public float[] carPosition;
    public GameObject player;
    public float playerPosition;
    public GameObject[] ai;
    public int currentPos;
    public int currentPoint;
    public TMP_Text posText;

    void Update()
    {
        PositionCalculation();
    }

    public void PositionCalculation()
    {
        carPosition[0] = player.GetComponent<PlayerDistance>().playerDistance;
        carPosition[1] = ai[0].GetComponent<AIDistance>().aiDistance;
        //carPosition[2] = ai[1].GetComponent<AIDistance>().aiDistance;
        //carPosition[3] = ai[2].GetComponent<AIDistance>().aiDistance;

        playerPosition = player.GetComponent<PlayerDistance>().playerDistance;

        Array.Sort(carPosition);
        int x = Array.IndexOf(carPosition, playerPosition);

        switch (x)
        {
            case 0:
                currentPos = 1;
                break;
            case 1:
                currentPos = 2;
                break;
            case 2:
                currentPos = 3;
                break;
            case 3:
                currentPos = 4;
                break;
        }
    }
}
