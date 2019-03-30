using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SiperControl : MonoBehaviour {

    public Button[] sper;
    public void SiperFalse()
    {
        for (int i = 0; i < sper.Length; i++)
        {
            sper[i].GetComponent<Image>().enabled = false;
            sper[i].interactable = false;
        }
    }
    public void SiperTrue()
    {
        for (int i = 0; i < sper.Length; i++)
        {
            sper[i].GetComponent<Image>().enabled = true;
            sper[i].interactable = true;
        }
    }
}
