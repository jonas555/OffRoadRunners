using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemLevelRequirement : MonoBehaviour
{
    [SerializeField] GameObject marusia;

    GlobalLevel levelSystem;

    void Update()
    {
        marusia.SetActive(false);
        transform.Find("Vehicles/Marusia").GetComponent<Button>();
        if (levelSystem.GetLevelNumber() >= 6)
        {                      
            marusia.SetActive(true);
        }
    }

    public void SetLevelSystem(GlobalLevel levelSystem)
    {
        this.levelSystem = levelSystem;
    }

    void UnlockFirebird()
    {
       
    }
}
