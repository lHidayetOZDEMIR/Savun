using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SperScript : MonoBehaviour {

    Images images;
    SiperControl siperControl;
    void Start () {
        images = FindObjectOfType<Images>();
        siperControl = FindObjectOfType<SiperControl>();
	}

    public void Konumlandir()
    {
        images.asker.transform.SetParent(images.clons, false);
        images.asker.transform.position = transform.position;
        siperControl.SiperFalse();
        images.ButtonControl();
    }

}
