using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmoteMenu : MonoBehaviour
{
    public GameObject emoteMenu;
    public GameObject emote1;
    public GameObject emote2;
    public GameObject emote3;
    public GameObject emote4;

    public int carImport;

    void Start()
    {
        emoteMenu = gameObject.transform.Find("EmoteInteraction").gameObject;
        carImport = CarSelection.carType;
        if (carImport == 0)
        {
            emote1 = gameObject.transform.Find("/Firebird_Driver/EmotePopups/Emote1").gameObject;
            emote2 = gameObject.transform.Find("/Firebird_Driver/EmotePopups/Emote2").gameObject;
            emote3 = gameObject.transform.Find("/Firebird_Driver/EmotePopups/Emote3").gameObject;
            emote4 = gameObject.transform.Find("/Firebird_Driver/EmotePopups/Emote4").gameObject;
        }

        if (carImport == 1)
        {
            emote1 = gameObject.transform.Find("/Miura400_Driver/EmotePopups/Emote1").gameObject;
            emote2 = gameObject.transform.Find("/Miura400_Driver/EmotePopups/Emote2").gameObject;
            emote3 = gameObject.transform.Find("/Miura400_Driver/EmotePopups/Emote3").gameObject;
            emote4 = gameObject.transform.Find("/Miura400_Driver/EmotePopups/Emote4").gameObject;
        }
    }

    void Update()
    {
        if (Input.GetButton("EmoteMenu") && !emoteMenu.activeSelf)
        {
            emoteMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        if (!Input.GetButton("EmoteMenu") && emoteMenu.activeSelf)
        {
            TurnOffEmoteMenu();
        }
    }

    public void TurnOffEmoteMenu()
    {
        emoteMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ActivateEmote1()
    {
        StartCoroutine((Emote1()));
    }

    public void ActivateEmote2()
    {
        StartCoroutine((Emote2()));
    }

    public void ActivateEmote3()
    {
        StartCoroutine((Emote3()));
    }

    public void ActivateEmote4()
    {
        StartCoroutine((Emote4()));
    }

    IEnumerator Emote1()
    {
        emote1.SetActive(true);
        yield return new WaitForSeconds(2f);
        emote1.SetActive(false);
    }

    IEnumerator Emote2()
    {
        emote2.SetActive(true);
        yield return new WaitForSeconds(2f);
        emote2.SetActive(false);
    }

    IEnumerator Emote3()
    {
        emote3.SetActive(true);
        yield return new WaitForSeconds(1f);
        emote3.SetActive(false);
    }

    IEnumerator Emote4()
    {
        emote4.SetActive(true);
        yield return new WaitForSeconds(2f);
        emote4.SetActive(false);
    }
}
