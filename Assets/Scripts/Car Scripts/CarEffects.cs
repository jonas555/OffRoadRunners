using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEffects : MonoBehaviour
{
    public Material brakeLights;
    public AudioSource skidClip;
    public TrailRenderer[] tireMarks;
    public ParticleSystem[] smoke;
    public ParticleSystem[] nitrusSmoke;
    public GameObject lights;
    private VC controller;
    private IM inputManager;
    private bool smokeRelease = false, lightsActive = false, tireMarksPlaced;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<VC>();
        inputManager = GetComponent<IM>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Drift();
        Smoke();
        Lights();
    }
    //Smoke Implementation
    private void Smoke()
    {
        if (controller.playPauseSmoke)
        {
            SmokeOn();
        }
        else
        {
            SmokeOff();
        }

        if (smokeRelease)
        {
            for (int i = 0; i < smoke.Length; i++)
            {
                var emission = smoke[i].emission;
                emission.rateOverTime = ((int)controller.KPH * 10 <= 2000) ? (int)controller.KPH * 10 : 2000;
            }
        }
    }

    //Smoke Effect Activation
    public void SmokeOn()
    {
        if (smokeRelease)
        {
            return;
        }

        for (int i = 0; i < smoke.Length; i++)
        {
            var emission = smoke[i].emission;
            emission.rateOverTime = ((int)controller.KPH * 2 >= 2000) ? (int)controller.KPH * 2 : 2000;
            smoke[i].Play();
        }
        smokeRelease = true;
    }

    public void SmokeOff()
    {
        if (!smokeRelease)
        {
            return;
        }
   
        for (int i = 0; i < smoke.Length; i++)
        {
            smoke[i].Stop();
        }
        smokeRelease = false;
    }

    //Nitro Effect Activation
    public void ActivateNitroMeeter()
    {
        if (controller.nitrusActive)
        {
            return;
        }

        for (int i = 0; i < nitrusSmoke.Length; i++)
        {
            nitrusSmoke[i].Play();
        }
        controller.nitrusActive = true;
    }

    public void StopNitroMeeter()
    {
        if (!controller.nitrusActive)
        {
            return;
        }

        for (int i = 0; i < nitrusSmoke.Length; i++)
        {
            nitrusSmoke[i].Stop();
        }
        controller.nitrusActive = false;

    }

    //Lights Effect Activation
    private void Lights()
    {
        if (inputManager.vertical < 0 || controller.KPH <= 1)
        {
            LightsOn();
        }
        else
        {
            LightsOff();
        }
    }
    
    private void LightsOn()
    {
        if (lightsActive)
        {
            return;
        }
        brakeLights.SetColor("_EmissionColor", Color.red * 5);
        lightsActive = true;
        //lights.SetActive(true);
    }

    private void LightsOff()
    {
        if (!lightsActive)
        {
            return;
        }
        brakeLights.SetColor("_EmissionColor", Color.black);
        lightsActive = false;
        //lights.SetActive(false);
    }

    //Drift Effect Activation
    private void Drift()
    {
        if (inputManager.handbrake)
        {
            StartEmmiter();
        }
        else
        {
            StopEmmiter();
        }

    }

    //Emmiters
    private void StartEmmiter()
    {
        if (tireMarksPlaced)
        {
            return;
        }
        //component renders a trail of polygons behind a moving GameObject
        foreach (TrailRenderer T in tireMarks)
        {
            T.emitting = true;
        }
        skidClip.Play();
        tireMarksPlaced = true;
    }

    private void StopEmmiter()
    {
        if (!tireMarksPlaced) return;
        foreach (TrailRenderer T in tireMarks)
        {
            T.emitting = false;
        }
        skidClip.Stop();
        tireMarksPlaced = false;
    }
}
