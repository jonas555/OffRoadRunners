using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectRotation : MonoBehaviour
{
    public float speed;
    public float AngularSpeed;
    protected Rigidbody r;
    public Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = r.velocity.magnitude;
        //AngularSpeed = r.angularVelocity.magnitude / (Mathf.PI * 2);
        AngularSpeed = r.angularVelocity.magnitude;

        //r.angularVelocity = new Vector3(0, Mathf.PI * 2, 0);
        r.AddTorque(Vector3.forward);
        transform.Translate(moveDirection, Space.World);
    }
}
