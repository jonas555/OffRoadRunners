using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementJumpTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {                
        //Collecting objects
        if (collider.gameObject.tag == "Player")
        {
            GlobalAchievement.achJumpCount += 1;
            Destroy(gameObject);
        }
    }
}
