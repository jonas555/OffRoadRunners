using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour
{
    public GameObject vehicle;    
    [SerializeField]
    private VC vehicleController;
    public ParticleSystem[] nitrusSmoke;
    public Rigidbody rb;
    public bool nitrusActive;

    void Awake()
    {
        vehicle = GameObject.FindGameObjectWithTag("Player");
        vehicleController = vehicle.GetComponent<VC>();
        rb = vehicle.GetComponent<Rigidbody>();       
    }

    public void HighSpeedStartAction()
    {
        for (int i = 0; i < nitrusSmoke.Length; i++)
        {
            nitrusSmoke[i].Play();
        }        
        rb.AddForce(transform.forward * 5000);
        nitrusActive = true;
    }

    public void HighSpeedEndAction()
    {
        for (int i = 0; i < nitrusSmoke.Length; i++)
        {
            nitrusSmoke[i].Stop();
        }        
        //rb.AddForce(transform.forward * 0);
        nitrusActive = false;
    }
}
