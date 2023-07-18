using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawner;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Instantiate(spawner, spawnPos.position, spawnPos.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
