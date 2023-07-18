using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersPosition : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Prototype Race")
        {                         
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            return;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Prototype Race")
        {            
            if (Input.GetKeyUp(KeyCode.R))
            {
                transform.position = gm.lastCheckPointPos;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            return;
        }
    }
}
