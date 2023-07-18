using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLevel
{
    public event EventHandler OnExperienceChange;
    public event EventHandler OnLevelChange;
    static readonly int[] experiencePerLevel = new[] { 100, 150, 200, 250, 300, 375, 450, 555, 625, 710 };
    int level;
    int experience;

    public GlobalLevel()
    {
        level = 0;
        experience = 0;
    }

    public void AddExperience(int amount)
    {
        if (!IsMaxLevel())
        {
            experience += amount;
            while (!IsMaxLevel() && experience >= GetExperienceToNextLevel(level))
            {
                experience -= GetExperienceToNextLevel(level);
                level++;                
                if (OnLevelChange != null)
                {
                    OnLevelChange(this, EventArgs.Empty);
                }
            }
            if (OnExperienceChange != null) OnExperienceChange(this, EventArgs.Empty);
        }       
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperiencNormalized()
    {
        if (IsMaxLevel())
        {
            return 1f;
        } else
        {
            return (float)experience / GetExperienceToNextLevel(level);
        }        
    }

    public int GetExperience()
    {
        return experience;
    }

    public int GetExperienceToNextLevel(int level)
    {
        if(level < experiencePerLevel.Length)
        {
            return experiencePerLevel[level];
        } else
        {
            return 100;
        }        
    }

    public bool IsMaxLevel()
    {
        return IsMaxLevel(level);
    }

    public bool IsMaxLevel(int level)
    {
        return level == experiencePerLevel.Length - 1;
    }
}
