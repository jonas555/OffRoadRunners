using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {                
        //Collecting objects
        if (collider.gameObject.tag == "Player")
        {
            GlobalAchievement.achCount += 1;
            Destroy(gameObject);
        }
     
        //Trigger an object
        /*if (collider.gameObject.tag == "Player")
        {
            GlobalAchievement.triggerAch01 = true;
            Destroy(gameObject);
        }*/
    }
}
