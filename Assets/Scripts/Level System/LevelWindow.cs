using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    public TMP_Text levelText;
    public Image experienceBarImage;
    GlobalLevel levelSystem;

    void Awake()
    {
        levelText = transform.Find("levelText").GetComponent<TMP_Text>();
        experienceBarImage = transform.Find("Slider").Find("Bar").GetComponent<Image>();

        transform.Find("5").GetComponent<Button>().onClick.AddListener(Add5Experience);
        transform.Find("50").GetComponent<Button>().onClick.AddListener(Add25Experience);
        transform.Find("500").GetComponent<Button>().onClick.AddListener(Add50Experience);
    }

    void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
    }

    void SetLevelNumber(int levelNumber)
    {
        levelText.text = "LEVEL " + (levelNumber + 1);
    }

    public void SetLevelSystem(GlobalLevel levelSystem)
    {
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperiencNormalized());

        levelSystem.OnExperienceChange += GlobalLevel_OnExperienceChange;
        levelSystem.OnLevelChange += GlobalLevel_OnLevelChange;
    }

    private void GlobalLevel_OnLevelChange(object sender, System.EventArgs e)
    {
        SetLevelNumber(levelSystem.GetLevelNumber());
    }

    private void GlobalLevel_OnExperienceChange(object sender, System.EventArgs e)
    {
        SetExperienceBarSize(levelSystem.GetExperiencNormalized());
    }

    void Add5Experience()
    {
        levelSystem.AddExperience(5);
    }

    public void Add25Experience()
    {
        levelSystem.AddExperience(50);
    }

    void Add50Experience()
    {
        levelSystem.AddExperience(500);
    }
}
