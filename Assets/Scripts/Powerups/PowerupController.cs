using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public GameObject powerupPrefab;

    public List<Powerup> powerups;

    public Dictionary<Powerup, float> activatePowerups = new Dictionary<Powerup, float>();

    private List<Powerup> keys = new List<Powerup>();
  
    public void HandleActivePowerups()
    {
        bool changed = false;

        if(activatePowerups.Count > 0)
        {
            foreach(Powerup powerup in keys)
            {
                if(activatePowerups[powerup] > 0)
                {
                    activatePowerups[powerup] -= Time.deltaTime;
                } else
                {
                    changed = true;
                    activatePowerups.Remove(powerup);
                    powerup.End();
                }
            }
        }

        if (changed)
        {
            keys = new List<Powerup>(activatePowerups.Keys);
        }
    }

    public void ActivatePowerup(Powerup powerup)
    {
        if (!activatePowerups.ContainsKey(powerup))
        {
            powerup.Start();
            activatePowerups.Add(powerup, powerup.duration);
        } else
        {
            activatePowerups[powerup] += powerup.duration;
        }

        keys = new List<Powerup>(activatePowerups.Keys);
    }

    public void ClearActivePowerups()
    {
        foreach (KeyValuePair<Powerup, float> Powerup in activatePowerups)
        {
            Powerup.Key.End();
        }

        activatePowerups.Clear();
    }

    void Update()
    {
        HandleActivePowerups();
    }

    public GameObject SpawnPowerup(Powerup powerup, Vector3 position)
    {
        GameObject powerupGameObject = Instantiate(powerupPrefab);

        var powerupBehaviour = powerupGameObject.GetComponent<PowerupBehaviour>();

        powerupBehaviour.controller = this;

        powerupBehaviour.SetPowerup(powerup);

        powerupGameObject.transform.position = position;

        return powerupGameObject;
    }
}
