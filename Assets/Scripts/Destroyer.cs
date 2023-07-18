using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime = 5f;

    void Update()
    {
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0)
            {
                Destruction();
            }
        }

        if(this.transform.position.y <= -20)
        {
            Destruction();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Destroyer")
        {
            Destruction();
        }
    }
    
    void Destruction()
    {
        Destroy(this.gameObject);
    }
}
