using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixer2;

    public void SetVolume(float environment)
    {
        audioMixer.SetFloat("environment", environment);
    }

    public void SetMusic(float music)
    {
        audioMixer2.SetFloat("music", music);
    }
}
