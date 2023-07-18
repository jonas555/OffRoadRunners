using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReverse : MonoBehaviour
{
    public GameObject RearViewImage;
    public GameObject RearViewCam;

    bool reverse;
    public int carImport;

    void Start()
    {
        carImport = CarSelection.carType;
        if (carImport == 0)
        {
            RearViewCam = gameObject.transform.Find("/Firebird_Driver/RearCamera").gameObject;
        } 
        if (carImport == 1)
        {
            RearViewCam = gameObject.transform.Find("/Miura400_Driver/RearCamera").gameObject;
        }
        RearViewCam.SetActive(true);        
        RearViewImage.SetActive(true);
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.B)) {
            if (reverse == false)
            {
                RearViewCam.SetActive(true);
                RearViewImage.SetActive(true);
                reverse = true;
            } else
            {
                RearViewCam.SetActive(false);
                RearViewImage.SetActive(false);
                reverse = false;
            }
            
        }*/
    }
}
