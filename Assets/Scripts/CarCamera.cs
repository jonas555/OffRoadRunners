using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamera : MonoBehaviour
{
    private GameObject vehicle;
    private VC vehicleController;
    private GameObject cameraConstraint; //constraint the camera position
    private GameObject cameraLookAt; //look at the object based on it position and follow it
    private float speed = 0; //the speed of following the object
    private float defaultFOV = 0 ,desiredFOV = 0; //default FOV on the current view and desired FOV when boosting
    [Range(0, 50)]public float smoothTime = 8; //the time of moving the camera way from the player while accelerating

    public int carImport;
    public GameObject firebird;
    public GameObject miura;

    // Start is called before the first frame update
    void Awake()
    {
        carImport = CarSelection.carType;
        if(carImport == 0)
        {
            miura.SetActive(false);
            vehicle = GameObject.FindGameObjectWithTag("Player");
            cameraConstraint = vehicle.transform.Find("Body/camera constraint").gameObject;
            cameraLookAt = vehicle.transform.Find("Body/camera lookAt").gameObject;
            vehicleController = vehicle.GetComponent<VC>();
            defaultFOV = Camera.main.fieldOfView;
            desiredFOV = defaultFOV + 15;
        }
        if(carImport == 1)
        {
            firebird.SetActive(false);
            vehicle = GameObject.FindGameObjectWithTag("Player");
            cameraConstraint = vehicle.transform.Find("Body/camera constraint").gameObject;
            cameraLookAt = vehicle.transform.Find("Body/camera lookAt").gameObject;
            vehicleController = vehicle.GetComponent<VC>();
            defaultFOV = Camera.main.fieldOfView;
            desiredFOV = defaultFOV + 15;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowCar();
        BoostFOV();
    }

    void FollowCar()
    {
        speed = vehicleController.KPH / smoothTime; //giving an effect of accelerating
        gameObject.transform.position = Vector3.Lerp(transform.position, cameraConstraint.transform.position, Time.deltaTime * speed);//target position and based position, also time
        gameObject.transform.LookAt(cameraLookAt.gameObject.transform.position); //follow the child               
    }

    void BoostFOV()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, desiredFOV, Time.deltaTime * 2);
        } else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFOV, Time.deltaTime * 2);
        }
    }
}
