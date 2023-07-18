using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public VC vehicleController;

    void Start()
    {
        vehicleController.GetComponent<VC>().enabled = true;
    }
}
