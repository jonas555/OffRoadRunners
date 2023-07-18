using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    public GameObject header;

    void Start()
    {
        StartCoroutine(LoadEntrance());
    }   

    IEnumerator LoadEntrance()
    {
        header.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(1);
    }
}
