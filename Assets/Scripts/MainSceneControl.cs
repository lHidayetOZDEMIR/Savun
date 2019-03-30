using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainSceneControl : MonoBehaviour {

    public GameObject marketMenu;
    public Text altinmiktari;
    AltinScript altinScript;
    SaveLoad saveLoad;

    void Start()
    {
        saveLoad = FindObjectOfType<SaveLoad>();
        saveLoad.Load();
    }
    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void Market()
    {
        marketMenu.SetActive(true);
        altinmiktari.text = "ALTIN: " + saveLoad.altinMiktari;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Geri()
    {
        marketMenu.SetActive(false);
    }

}
