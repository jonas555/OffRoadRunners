using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IM : MonoBehaviour
{
    /*internal enum driver
    {
        AI,
        Human,
        Mobile
    }
    [SerializeField] driver driverController;
    */
    [HideInInspector] public float vertical;
    [HideInInspector] public float horizontal;
    [HideInInspector] public bool handbrake;
    [HideInInspector] public bool boost = true;

    public TrackerWaypoints waypoints;
    public Transform currentWaypoint;
    public List<Transform> nodes = new List<Transform>();
    [Range(0, 10)] public int distanceOffset;
    [Range(0, 5)] public float steerForce;
    [Header("AI acceleration value")]
    [Range(0, 1)] public float acceleration = 0.5f;
    public int currentNode;

    void Awake()
    {
        if (gameObject.tag == "AI")
        {
            //waypoints = GameObject.FindGameObjectWithTag("Path").GetComponent<TrackerWaypoints>();
            currentWaypoint = gameObject.transform;
            nodes = waypoints.nodes;
        }
    }

    void FixedUpdate()
    {
        /*switch (driverController)
        {
            case driver.AI:
                AIDrive();
                break;
            case driver.Human:
                Keyboard();
                break;
            case driver.Mobile:
                break;
        }*/
        if (gameObject.tag == "AI") AIDrive();
        else if (gameObject.tag == "Player")
        {
            CalculateDistanceOfWaypoints();
            Keyboard();
        }
        
    }

    void AIDrive()
    {
        CalculateDistanceOfWaypoints();
        vertical = acceleration;
        AISteer();
    }

    void Keyboard()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        handbrake = (Input.GetAxis("Jump") != 0) ? true : false;
        if (Input.GetKey(KeyCode.LeftShift)) boost = true;
        else boost = false;
    }

    void MobileDrive()
    {

    }

    void CalculateDistanceOfWaypoints()
    {
        Vector3 position = gameObject.transform.position;
        float distance = Mathf.Infinity;

        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 difference = nodes[i].transform.position - position;
            float currentDistance = difference.magnitude;
            if (currentDistance < distance)
            {
                if ((i + distanceOffset) >= nodes.Count)
                {
                    currentWaypoint = nodes[1];
                    distance = currentDistance;
                }
                else
                {
                    currentWaypoint = nodes[i + distanceOffset];
                    distance = currentDistance;
                }
                currentNode = i;
            }
        }
    }

    void AISteer()
    {
        Vector3 relative = transform.InverseTransformPoint(currentWaypoint.transform.position);
        relative /= relative.magnitude;

        horizontal = (relative.x / relative.magnitude) * steerForce;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(currentWaypoint.position, 3);
    }*/
}
