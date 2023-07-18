using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target;
    public float speedMod = 1.0f;
    private Vector3 point;

    void Start()
    {
        point = target.transform.position;
        transform.LookAt(point);
    }

    void Update()
    {
        transform.RotateAround(point, new Vector3(0.0f, -1.0f, 0.0f), 20 * Time.deltaTime * speedMod);
    }
}
