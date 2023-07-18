using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    public PowerupController controller;

    [SerializeField]
    private Powerup powerup;

    private Transform transform_;

    void Awake()
    {
        transform_ = transform;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            ActivatePowerup();
            gameObject.SetActive(false);
        }
    }

    void ActivatePowerup()
    {
        controller.ActivatePowerup(powerup);
    }

    public void SetPowerup(Powerup powerup)
    {
        this.powerup = powerup;
        gameObject.name = powerup.name;
    }
}
