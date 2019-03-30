using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AltinScript : MonoBehaviour {

    public Text altinText;
    public float altinMiktari;
    SaveLoad saveLoad;
    //public static AltinScript obje = null;
    //void Awake()
    //{
    //    if (obje == null)
    //    {
    //        obje = this;
    //        DontDestroyOnLoad(this);
    //    }
    //    else if (this != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    void Start()
    {
        //saveLoad.altinMiktari = altinMiktari;
        //saveLoad.Load();
    }
    public void UpdateAltin()
    {
        altinText.text = "ALTIN: "+altinMiktari ;
    }
}
