using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShow : MonoBehaviour
{
    public GameObject ruleTable;
    public GameObject questionM;
    public GameObject gameplay;
    public GameObject infoBtn;

    public void Enable()
    {
        ruleTable.SetActive(true);       
        questionM.SetActive(false);
        infoBtn.SetActive(false);
    }

    public void Disable()
    {
        ruleTable.SetActive(false);
        gameplay.SetActive(false);
        questionM.SetActive(true);
        infoBtn.SetActive(true);
    }

    public void GamePlayInfo()
    {
        gameplay.SetActive(true);
        infoBtn.SetActive(false);
        questionM.SetActive(false);
    }
}
