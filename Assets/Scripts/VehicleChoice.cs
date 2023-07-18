using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleChoice : MonoBehaviour
{
    public GameObject firebird;
    public GameObject miura;
    public GameObject[] AIfirebird;
    public GameObject[] AImiura;
    public int carImport;

    void Start()
    {        
        carImport = CarSelection.carType;
        if(carImport == 0)
        {
            firebird.SetActive(true);
            AIfirebird[0].SetActive(true);
            AIfirebird[1].SetActive(true);
            miura.SetActive(false);
            AImiura[0].SetActive(false);
            AImiura[1].SetActive(false);
        }
        if (carImport == 1)
        {
            miura.SetActive(true);
            AImiura[0].SetActive(true);
            AImiura[1].SetActive(true);
            firebird.SetActive(false);
            AIfirebird[0].SetActive(false);
            AIfirebird[1].SetActive(false);
        }
      
    }
}
