using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAchievement : MonoBehaviour
{
    public GameObject achPanel;
    public AudioSource achSound;
    public bool achActive = false;
    //public GameObject achHeader;

    //Collectables achievement
    public GameObject ach01Image;   
    public GameObject ach02Image;
    public GameObject ach03Image;
    public static int achCount = 0;
    public int ach01Number = 1;
    public int ach02Number = 2;
    public int ach03Number = 3;
    public int achBronzeCode;
    public int achSilverCode;
    public int achGoldCode;

    //Bridge Jump
    public GameObject achJump;
    public static int achJumpCount = 0;
    public int achJumpNumber = 1;
    public int achJumpCode;

    void Start()
    {
        //Win races achievements
        achBronzeCode = PlayerPrefs.GetInt("bronze");
        achSilverCode = PlayerPrefs.GetInt("silver");
        achGoldCode = PlayerPrefs.GetInt("gold");
        Debug.Log("bronze number: " + PlayerPrefs.GetInt("bronze"));
        Debug.Log("silver number: " + PlayerPrefs.GetInt("silver"));
        Debug.Log("gold number: " + PlayerPrefs.GetInt("gold"));

        //Jumps
        achJumpCode = PlayerPrefs.GetInt("Jump");
        Debug.Log("Jump Code is: " + achJumpCount);
    }

    // Update is called once per frame
    void Update()
    {
        //Wins
        achBronzeCode = PlayerPrefs.GetInt("bronze");       
        achSilverCode = PlayerPrefs.GetInt("silver");
        achGoldCode = PlayerPrefs.GetInt("gold");
        
        //Wins
        if (achCount == ach01Number && achBronzeCode != 1)
        {
            StartCoroutine(Trigger01Ach());
            Debug.Log(achCount);
        }       
        if (achCount == ach02Number && achSilverCode != 2)
        {          
            StartCoroutine(Trigger02Ach());
            Debug.Log(achCount);
        }       
        if (achCount == ach03Number && achGoldCode != 3)
        {           
            StartCoroutine(Trigger03Ach());
            Debug.Log(achCount);
        }

        //Jumps
        achJumpCode = PlayerPrefs.GetInt("Jump");

        //Jumps
        if (achJumpCount == achJumpNumber && achJumpCode != 1)
        {
            StartCoroutine(TriggerJump());
        }
    } 

    //Wins
    IEnumerator Trigger01Ach()
    {
        achActive = true;
        achBronzeCode = 1;
        PlayerPrefs.SetInt("bronze", achBronzeCode);
        PlayerPrefs.Save();
        achSound.Play();
        ach01Image.SetActive(true);
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        achPanel.SetActive(false);
        ach01Image.SetActive(false);
        achActive = false;
    }

    IEnumerator Trigger02Ach()
    {
        achActive = true;
        achSilverCode = 2;
        PlayerPrefs.SetInt("silver", achSilverCode);
        PlayerPrefs.Save();
        achSound.Play();
        ach02Image.SetActive(true);
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        achPanel.SetActive(false);
        ach02Image.SetActive(false);
        achActive = false;
    }

    IEnumerator Trigger03Ach()
    {
        achActive = true;
        achGoldCode = 3;
        PlayerPrefs.SetInt("gold", achGoldCode);
        PlayerPrefs.Save();
        achSound.Play();
        ach03Image.SetActive(true);
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        achPanel.SetActive(false);
        ach03Image.SetActive(false);
        achActive = false;
    }

    //Jumps
    IEnumerator TriggerJump()
    {
        achActive = true;
        achJumpCode = 1;
        PlayerPrefs.SetInt("Jump", achJumpCode);
        PlayerPrefs.Save();
        achSound.Play();
        achJump.SetActive(true);
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        achPanel.SetActive(false);
        achJump.SetActive(false);
        achActive = false;
    }
}
