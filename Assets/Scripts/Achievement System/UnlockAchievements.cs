using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockAchievements : MonoBehaviour
{
    public GameObject bronze;
    public GameObject silver;
    public GameObject gold;
    public GameObject jump;

    public int bronzeCode;
    public int silvercode;
    public int goldCode;
    public int jumpCode;

    // Update is called once per frame
    void Update()
    {
        WinsAchievements();
        JumpAchievements();
    }

    void WinsAchievements()
    {
        bronzeCode = PlayerPrefs.GetInt("bronze");
        silvercode = PlayerPrefs.GetInt("silver");
        goldCode = PlayerPrefs.GetInt("gold");

        if (bronzeCode == 1)
        {
            bronze.SetActive(true);
        }
        else
        {
            bronze.SetActive(false);
        }

        if (silvercode == 2)
        {
            silver.SetActive(true);
        }
        else
        {
            silver.SetActive(false);
        }

        if (goldCode == 3)
        {
            gold.SetActive(true);
        }
        else
        {
            gold.SetActive(false);
        }
    }

    void JumpAchievements()
    {
        jumpCode = PlayerPrefs.GetInt("Jump");

        if (jumpCode == 1)
        {
            jump.SetActive(true);
        }
        else
        {
            jump.SetActive(false);
        }
    }
}
