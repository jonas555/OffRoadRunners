using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VC : MonoBehaviour
{
    internal enum driveType
    {
        frontWheelDrive,
        rearWheelDrive,
        allWheelDrive
    }
    [SerializeField] private driveType drive;

    private GameManager manager;
    private IM inputManager;
    private CarEffects effects;
    public bool test; //meant to test the last value of the engine rpm

    public float handBrakeFrictionMultiplier = 2f;//the value of drifting presure, the higher it is, the less drifts the vehicle
    public float maxRPM, minRPM;
    public float[] gears; //gear ratio
    public float[] gearChangeSpeed; //the speed of gear acceleration
    public AnimationCurve enginePower;

    public int gearNum = 1;
    public bool playPauseSmoke = false, hasFinished;
    public float KPH; //kilometers per hour
    public float engineRPM; //the engines RPM value
    public bool reverse = false;
    public float nitrusValue;
    public bool nitrusActive = false;

    private GameObject wheelMeshes, wheelColliders;
    public WheelCollider[] wheelCollider = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    private GameObject centerOfMass; //center of the vehicle mass is focused from the rb
    private Rigidbody rb; //calculates the speed as well

    private float smoothTime = 0.09f;

    private WheelFrictionCurve forwardFriction, sidewaysFriction; //tires slip friction curve
    public float radius = 6, brakePower = 50000, DownForceValue = 100f, wheelsRPM, driftFactor, lastValue, horizontal, vertical, totalPower;
    public bool activation = false; //activation of the engine

    void Awake()
    {      
        GetObjects();
        StartCoroutine(TimedLoop());       
    }

    void FixedUpdate()
    {
        horizontal = inputManager.horizontal;
        vertical = inputManager.vertical;

        lastValue = engineRPM;

        AddDownForce();
        AnimateWheels();
        SteerVehicle();
        CalculateEnginePower();
        if (gameObject.tag == "AI") return;
        AdjustTraction();
        ActivateNitrus();
    }

    void CalculateEnginePower() //calculation of the engine based on the wheelRPM
    {
        WheelRPM();

        //checks if we are driving vertically
        if (vertical != 0)
        {
            rb.drag = 0.005f;//decrease the rotation of the object
        }
        if (vertical == 0)
        {
            rb.drag = 0.1f;//set do default
        }
        //the overall power engine = 3.6f (kph) * the power of the engine (based on the curve) *dot* evaluation of the engines horse power * vertical input direction
        totalPower = 3.6f * enginePower.Evaluate(engineRPM) * (vertical);


        float velocity = 0.0f; //velocity default
        if (engineRPM >= maxRPM || activation) //if enginesRPM is greater/equal Maxrpm or is activated
        {
            engineRPM = Mathf.SmoothDamp(engineRPM, maxRPM - 500, ref velocity, 0.05f); //start calculating

            activation = (engineRPM >= maxRPM - 450) ? true : false; //start engine
            test = (lastValue > engineRPM) ? true : false; //check the last velue of engine rpm
        }
        else
        {
            //Mathf.SmoothDamp(current engines RPM (anim curve), 1000 + desired rpm, ref the velocity, smoothtime of engine)
            engineRPM = Mathf.SmoothDamp(engineRPM, 1000 + (Mathf.Abs(wheelsRPM) * 3.6f * (gears[gearNum])), ref velocity, smoothTime);
            test = false;
        }
        if (engineRPM >= maxRPM + 1000) engineRPM = maxRPM + 1000;
        DriveVehicle();
        ShiftGear();
    }

    void WheelRPM() //calculation of the engine RPM requirement component
    {
        float sum = 0; //rpm
        int R = 0; //gears
        for (int i = 0; i < 4; i++) //getting all the wheels
        {
            sum += wheelCollider[i].rpm; //the current rpm being updated for each vheel
            R++; //gear increase
        }

        //value of wheels going forward or backwards
        wheelsRPM = (R != 0) ? sum / R : 0; //if gear != 0 (not idle) then the rpm / R (rpm divided by gear number) else its not being used

        if (wheelsRPM < 0 && !reverse) //checking if we are not driving reverse
        {
            reverse = true;
            if (gameObject.tag != "AI") manager.ChangeGear();
        }
        else if (wheelsRPM > 0 && reverse) //if we are driving forward
        {
            reverse = false;
            if (gameObject.tag != "AI") manager.ChangeGear();
        }
    }

    private bool CheckGears()
    {
        //checks if the kph is greater/equals to the gear speed change (gear num)
        if (KPH >= gearChangeSpeed[gearNum]) return true;
        else return false;
    }

    private void ShiftGear()
    {
        if (!isGrounded()) return;
        //automatic
        //check if the engine rpm is above the max & 
        //the gears value is not hitting the limit of the gears length (upshift or downshift) & 
        //if its not reversing & check gears for speed update
        if (engineRPM > maxRPM && gearNum < gears.Length - 1 && !reverse && CheckGears())
        {
            gearNum++;//increase gear
            if (gameObject.tag != "AI") manager.ChangeGear(); //check if the player is not an AI
            return;
        }
        //checks if the rpm is decreasing (downshifts) and above 0
        if (engineRPM < minRPM && gearNum > 0) 
        {
            gearNum--;//decrease gear and prevents to go under 0
            if (gameObject.tag != "AI") manager.ChangeGear();
        }
    }

    private bool isGrounded()
    {
        //fir the shift gear to prevent accelerating when on air, only if the wheels are grounded
        if (wheelCollider[0].isGrounded && wheelCollider[1].isGrounded && wheelCollider[2].isGrounded && wheelCollider[3].isGrounded)
            return true;
        else
            return false;
    }

    private void DriveVehicle()
    {
        Brakes();

        if (drive == driveType.allWheelDrive)//if all wheel drive
        {
            for (int i = 0; i < wheelCollider.Length; i++) //get all wheel colliders
            {
                wheelCollider[i].motorTorque = totalPower / 4; //motorTorque = the total power being driven divided by 4 (for all the wheels), balancing the power
                wheelCollider[i].brakeTorque = brakePower; //brake power 
            }
        }
        else if (drive == driveType.rearWheelDrive)//if only back wheel drive
        {
            wheelCollider[2].motorTorque = totalPower / 2; //divide the back in two for balancing its drive power
            wheelCollider[3].motorTorque = totalPower / 2; //divide the back in two for balancing its drive power

            for (int i = 0; i < wheelCollider.Length; i++)
            {
                wheelCollider[i].brakeTorque = brakePower; //brake power for all wheels
            }
        }
        else //if only front wheel drive
        {
            wheelCollider[0].motorTorque = totalPower / 2; //same thing for the rear
            wheelCollider[1].motorTorque = totalPower / 2; //same thing for the rear

            for (int i = 0; i < wheelCollider.Length; i++)
            {
                wheelCollider[i].brakeTorque = brakePower; //brake power for all wheels
            }
        }

        KPH = rb.velocity.magnitude * 3.6f; //calculation of the kilometers
        //(60X60/1000)
        //if to mph = rb.velocity.magnitude * 0.621371f
    }

    private void Brakes()
    {
        if (vertical < 0) //if the speed (vertical) is less than 0
        {
            brakePower = (KPH >= 10) ? 500 : 0; //if kph is greater or equals to 10, then brakePower is equals to 500 else its 0
        }
        else if (vertical == 0 && (KPH <= 10 || KPH >= -10)) //if the vertical speed is equals to 0 & kph <= 10 or >= -10
        {
            brakePower = 10;
        }
        else //if the handbrake is not being used
        {
            brakePower = 0;
        }
    }

    private void SteerVehicle()
    {
        //acerman steering formula
        if (horizontal > 0) //steer to the right
        {
            //turns one wheel more for it to finish the turn rather than drifting
            wheelCollider[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * horizontal; 
            wheelCollider[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * horizontal;
        }
        else if (horizontal < 0) //steer to the left
        {
            wheelCollider[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * horizontal;
            wheelCollider[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * horizontal;
        }
        else //set to default 0
        {
            wheelCollider[0].steerAngle = 0;
            wheelCollider[1].steerAngle = 0;
        }
    }

    private void AnimateWheels()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheelCollider[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }

    void GetObjects()
    {
        inputManager = GetComponent<IM>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        effects = GetComponent<CarEffects>();
        rb = GetComponent<Rigidbody>();
        wheelColliders = gameObject.transform.Find("Body/WheelCollider").gameObject;
        wheelMeshes = gameObject.transform.Find("Body/WheelMesh").gameObject;
        wheelCollider[0] = wheelColliders.transform.Find("FL").gameObject.GetComponent<WheelCollider>();
        wheelCollider[1] = wheelColliders.transform.Find("FR").gameObject.GetComponent<WheelCollider>();
        wheelCollider[2] = wheelColliders.transform.Find("BL").gameObject.GetComponent<WheelCollider>();
        wheelCollider[3] = wheelColliders.transform.Find("BR").gameObject.GetComponent<WheelCollider>();

        wheelMesh[0] = wheelMeshes.transform.Find("FL").gameObject;
        wheelMesh[1] = wheelMeshes.transform.Find("FR").gameObject;
        wheelMesh[2] = wheelMeshes.transform.Find("BL").gameObject;
        wheelMesh[3] = wheelMeshes.transform.Find("BR").gameObject;
        
        //prevention for the vehicle flipping over but gives some drift
        centerOfMass = gameObject.transform.Find("Body/centermass").gameObject; //center of gravity
        GetComponent<Rigidbody>().centerOfMass = centerOfMass.transform.localPosition; // alocates the centermass to give the object the main mass based on its transform localposition
    }

    private void AddDownForce()
    {
        //adding the force of thecar while moving it, based on the Y axis (-transform.up) 
        //it represents the - value of Y times the downforce value, giving it the weight of the vehicle sticking to the road
        rb.AddForce(-transform.up * DownForceValue * rb.velocity.magnitude); 
    }

    private void AdjustTraction()
    {        
        //time it takes to go from normal drive to drift 
        float driftSmothFactor = .7f * Time.deltaTime;

        if (inputManager.handbrake) //if handbrake is not being held
        {
            sidewaysFriction = wheelCollider[0].sidewaysFriction; //get the sidewayFriction from the wheelCollider
            forwardFriction = wheelCollider[0].forwardFriction; //get the forwardFriction from the wheelCollider

            //passed in the SmoothDamp as a reference parameter
            //once the SmoothDamp is called the velocity will hold the newly assigned value which you can use it later
            float velocity = 0; //default rb rate position 

            //extremumValue is a Static that allows the wheels to slip
            //asymptoteValue is a dynamic that alow the wheels to resist the movement once its start moving
            //the values are the required amount of force to "break free" for Static Friction and the amount of "level out" (stop dropping) for Dynamic Friction
            sidewaysFriction.extremumValue = sidewaysFriction.asymptoteValue = forwardFriction.extremumValue = forwardFriction.asymptoteValue =
                Mathf.SmoothDamp(forwardFriction.asymptoteValue, driftFactor * handBrakeFrictionMultiplier, ref velocity, driftSmothFactor);

            for (int i = 0; i < 4; i++) //loop through the wheels
            {
                wheelCollider[i].sidewaysFriction = sidewaysFriction;
                wheelCollider[i].forwardFriction = forwardFriction;
            }

            sidewaysFriction.extremumValue = sidewaysFriction.asymptoteValue = forwardFriction.extremumValue = forwardFriction.asymptoteValue = 1.1f;

            //extra grip for the front wheels
            for (int i = 0; i < 2; i++)
            {
                wheelCollider[i].sidewaysFriction = sidewaysFriction;
                wheelCollider[i].forwardFriction = forwardFriction;
            }

            //add force for the vehicle which the kph value is divided by 100 and times 10k for balance purpase
            rb.AddForce(transform.forward * (KPH / 400) * 10000);
        }
        //executed when handbrake is being held
        else
        {
            forwardFriction = wheelCollider[0].forwardFriction;
            sidewaysFriction = wheelCollider[0].sidewaysFriction;

            forwardFriction.extremumValue = forwardFriction.asymptoteValue = sidewaysFriction.extremumValue = sidewaysFriction.asymptoteValue =
            ((KPH * handBrakeFrictionMultiplier) / 300) + 1;

            for (int i = 0; i < 4; i++)
            {
                wheelCollider[i].forwardFriction = forwardFriction;
                wheelCollider[i].sidewaysFriction = sidewaysFriction;
            }
        }

        //checks the amount of slip to control the drifting
        for (int i = 2; i < 4; i++)
        {
            WheelHit wheelHit;
            wheelCollider[i].GetGroundHit(out wheelHit);

            //smoke
            if (wheelHit.sidewaysSlip >= 0.3f || wheelHit.sidewaysSlip <= -0.3f || wheelHit.forwardSlip >= .3f || wheelHit.forwardSlip <= -0.3f)
            {
                playPauseSmoke = true;
            }
            else
            {
                playPauseSmoke = false;
            }

            if (wheelHit.sidewaysSlip < 0)
            {
                driftFactor = (1 + -inputManager.horizontal) * Mathf.Abs(wheelHit.sidewaysSlip);
            }
            if (wheelHit.sidewaysSlip > 0)
            {
                driftFactor = (1 + inputManager.horizontal) * Mathf.Abs(wheelHit.sidewaysSlip);
            }
        }
    }

    //time loop for the steering to prevent sterring higher in high speeds
    private IEnumerator TimedLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(.7f);
            radius = 6 + KPH / 10;

        }
    }
    
    public void ActivateNitrus()
    {       
        //if the boost is not active and the value of nitro is not bellow/equal 15
        if (!inputManager.boost && nitrusValue <= 15)
        {
            nitrusValue += Time.deltaTime / 3;//increase the value
        }
        else
        {
            //clamping the value
            //for got to add the Time.deltaTime / 2 to remove the boost faster
            nitrusValue -= (nitrusValue <= 0) ? 0 : Time.deltaTime; //if we are boosting
        }

        if (inputManager.boost)//if nitrus is active
        {
            if (nitrusValue > 0)  //if the value is greater
            {
                effects.ActivateNitroMeeter();
                rb.AddForce(transform.forward * 5000); //add force when boosting
            }
            else effects.StopNitroMeeter();
        }
        else effects.StopNitroMeeter();
    }
}
