using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    public GameObject cam2;
    public GameObject cam1;
    public GameObject camReverse;
    public CarCamera camMain;

    public GameObject UI;
    public CountdownAudio countdownManager;
    public GameObject uiInteraction;

    public int carImport;
    public GameObject firebird;
    public GameObject miura;

    // Start is called before the first frame update
    void Start()
    {
        carImport = CarSelection.carType;
        if (carImport == 0 && firebird == true)
        {
            camMain = GameObject.Find("Firebird_Driver/Main Camera").GetComponent<CarCamera>();
        }
        if (carImport == 1 && miura == true)
        {
            camMain = GameObject.Find("Miura400_Driver/Main Camera").GetComponent<CarCamera>();
        }
        cam2.SetActive(true);
        uiInteraction.SetActive(true);
        cam1.SetActive(false);        
        camReverse.SetActive(false);
        UI.SetActive(false);             
        StartCoroutine(Cuts());
    }

    IEnumerator Cuts()
    {
        yield return new WaitForSeconds(4);        
        cam1.SetActive(true);
        uiInteraction.SetActive(false);
        cam2.SetActive(false);
        yield return new WaitForSeconds(5);
        camMain.enabled = true;
        camReverse.SetActive(true);
        cam1.SetActive(false);
        UI.SetActive(true);
        countdownManager.enabled = true;
    }
}
