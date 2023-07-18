using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrigger;
    public GameObject HalfLapTrigger;

    //public GameObject minDisplay;
    //public GameObject secDisplay;
    //public GameObject milliDisplay;

    public GameObject myVehicle;

    public GameObject lapCounter;
    public int lapsChecked;

    public int achBronzeCode;
    public int triggered2;
    public int achSilverCode;
    public int triggered4;
    public int achGoldCode;
    public GameObject achTrigger;

    //Delete Maybe
    //public float trackTime;

    public GameObject raceFinish;

    void Awake()
    {
        //Wins
        achBronzeCode = PlayerPrefs.GetInt("bronze");
        triggered2 = PlayerPrefs.GetInt("closeToSilver");
        achSilverCode = PlayerPrefs.GetInt("silver");
        triggered4 = PlayerPrefs.GetInt("closeToGold");
        achGoldCode = PlayerPrefs.GetInt("gold");

        myVehicle = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //Player Lap Count
        if(lapsChecked == 2)
        {
            //Wins
            achBronzeCode = PlayerPrefs.GetInt("bronze");
            triggered2 = PlayerPrefs.GetInt("closeToSilver");
            achSilverCode = PlayerPrefs.GetInt("silver");
            triggered4 = PlayerPrefs.GetInt("closeToGold");
            achGoldCode = PlayerPrefs.GetInt("gold");

            raceFinish.SetActive(true);
            LapCompleteTrigger.SetActive(false);

            //Wins
            if(achBronzeCode != 1)
            {
                achTrigger.SetActive(true);
            }
            if (achBronzeCode == 1 && triggered2 != 2)
            {
                achTrigger.SetActive(true);
            }
            if (triggered2 == 2 && achSilverCode != 3)
            {
                achTrigger.SetActive(true);
            }
            if (achSilverCode == 3 && triggered4 != 4)
            {
                achTrigger.SetActive(true);
            }
            if (triggered4 == 4 && achGoldCode != 5)
            {
                achTrigger.SetActive(true);
            }           
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Player Lap Count Trigger
        if (collider.gameObject.tag == "Player")
        {
            lapsChecked += 1;
            /*rawTime = PlayerPrefs.GetFloat("RawTime");

            if (TimeLapManager.trackTime <= rawTime)
            {
                if (TimeLapManager.SecondCount <= 9)
                {
                    secDisplay.GetComponent<TMP_Text>().text = "0" + TimeLapManager.SecondCount + ".";
                }
                else
                {
                    secDisplay.GetComponent<TMP_Text>().text = "" + TimeLapManager.SecondCount + ".";
                }

                if (TimeLapManager.MinuteCount <= 9)
                {
                    minDisplay.GetComponent<TMP_Text>().text = "0" + TimeLapManager.MinuteCount + ".";
                }
                else
                {
                    minDisplay.GetComponent<TMP_Text>().text = "" + TimeLapManager.MinuteCount + ".";
                }

                milliDisplay.GetComponent<TMP_Text>().text = "" + TimeLapManager.MilliCount.ToString("F0");
            }*/


            /*PlayerPrefs.SetInt("MinSave", TimeLapManager.MinuteCount);
            PlayerPrefs.SetInt("SecSave", TimeLapManager.SecondCount);
            PlayerPrefs.SetFloat("MilliSave", TimeLapManager.MilliCount);
            PlayerPrefs.SetFloat("SaveTrackTime", TimeLapManager.trackTime);

            TimeLapManager.MinuteCount = 0;
            TimeLapManager.SecondCount = 0;
            TimeLapManager.MilliCount = 0;
            TimeLapManager.trackTime = 0;*/

            lapCounter.GetComponent<TMP_Text>().text = "" + lapsChecked;
            HalfLapTrigger.SetActive(true);
            LapCompleteTrigger.SetActive(false);
            achTrigger.SetActive(false);
        }
    }
}
