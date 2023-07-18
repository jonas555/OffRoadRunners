using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointCircuit : MonoBehaviour
{
    public GameObject textSafe;
    private GameManager gm;

    public int Index;
    public LapCount lap;

    void Start()
    {
        textSafe.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        lap = GameObject.FindGameObjectWithTag("Player").GetComponent<LapCount>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") //collider.Compare("Player")
        {
            gm.lastCheckPointPos = transform.position;
            gm.lastCheckPointRot = transform.rotation;
            if (lap.checkpointIndex == Index + 1 || lap.checkpointIndex == Index - 1)
            {
                lap.checkpointIndex = Index;
                StartCoroutine(ShowCheckpointText());
                Debug.Log("Players checkpoint " + Index);
            }           
        }
    }

    IEnumerator ShowCheckpointText()
    {
        textSafe.SetActive(true);
        yield return new WaitForSeconds(1f);
        textSafe.SetActive(false);
    }
}
