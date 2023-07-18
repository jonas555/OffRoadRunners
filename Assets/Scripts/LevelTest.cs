using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTest : MonoBehaviour
{
    [SerializeField] LevelWindow levelWindow;
    [SerializeField] ItemLevelRequirement vehicleLevel;

    void Awake()
    {
        GlobalLevel levelSystem = new GlobalLevel();      
        levelWindow.SetLevelSystem(levelSystem);
        vehicleLevel.SetLevelSystem(levelSystem);
    }
}
