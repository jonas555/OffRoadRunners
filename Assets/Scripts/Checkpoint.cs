using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public GameObject textSafe;
    private GameManager gm;
    public GameObject minSafe;
    public GameObject secSafe;
    public GameObject milliSafe;

    private bool hasCollider = false;

    void Start()
    {
        textSafe.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();         
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (hasCollider == false)
            {
                hasCollider = true;
                gm.lastCheckPointPos = transform.position;
                gm.lastCheckPointRot = transform.rotation;
                minSafe.GetComponent<TMP_Text>().text = "0" + TimeLapManager.MinuteCount + ":";
                secSafe.GetComponent<TMP_Text>().text = "0" + TimeLapManager.SecondCount + ".";
                milliSafe.GetComponent<TMP_Text>().text = "0" + TimeLapManager.MilliCount.ToString("F0");
                StartCoroutine(ShowCheckpointText());
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
