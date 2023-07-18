using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public VC vehicleController;
    public GameObject needle;
    public Text kph;
    public Text gear;
    public Image nitrusSlider;
    private float startPosition = 306f, endPosition = -84f;
    private float desiredPosition;

    private static GameManager instance;
    public Vector3 lastCheckPointPos;
    public Quaternion lastCheckPointRot;

    public int carImport;
    public GameObject firebird;
    public GameObject miura;

    void Awake()
    {
        carImport = CarSelection.carType;
        if(carImport == 0 && firebird == true)
        {            
            miura.SetActive(false);
            vehicleController = GameObject.FindGameObjectWithTag("Player").GetComponent<VC>();
        }
        if (carImport == 1 && miura == true)
        {
            firebird.SetActive(false);
            vehicleController = GameObject.FindGameObjectWithTag("Player").GetComponent<VC>();
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        kph.text = vehicleController.KPH.ToString("0");
        UpdateNeedle();
        NitroUI();             
    }

    public void UpdateNeedle()
    {
        desiredPosition = startPosition - endPosition;
        float temp = vehicleController.engineRPM / 4000;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * desiredPosition));
    }

    public void ChangeGear()
    {
        gear.text = (!vehicleController.reverse) ? (vehicleController.gearNum + 1).ToString() : "R";
    }

    public void NitroUI()
    {
        nitrusSlider.fillAmount = vehicleController.nitrusValue / 45;
    }
}
