using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionCamera : MonoBehaviour
{
    public GameObject main;
    public GameObject selection;
    public Button changeViewToSelection;
    public Button changeViewToMainMenu;
    public GameObject mainMenu;
    public GameObject selectionMenu;
    public GameObject trackSelection;
    public GameObject vehiclesList;
    public GameObject optionsMenu;
    public GameObject achievementMenu;

    void Start()
    {      
        main.SetActive(true);
        selection.SetActive(false);
        optionsMenu.SetActive(false);
        achievementMenu.SetActive(false);
    }   

    public void ChangeCameraToSelectionMenu()
    {       
        mainMenu.SetActive(false);
        selectionMenu.SetActive(true);
        vehiclesList.SetActive(true);
        main.SetActive(false);
        selection.SetActive(true);
        optionsMenu.SetActive(false);
        achievementMenu.SetActive(false);
    }

    public void ChangeCameraToMainMenu()
    {       
        mainMenu.SetActive(true);
        selectionMenu.SetActive(false);
        trackSelection.SetActive(false);
        vehiclesList.SetActive(false);
        main.SetActive(true);
        selection.SetActive(false);
        optionsMenu.SetActive(false);
        achievementMenu.SetActive(false);
    }

    
}
