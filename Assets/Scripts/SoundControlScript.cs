using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControlScript : MonoBehaviour {

    public AudioClip [] cannonsound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Cal(int i)
    {
        
            AudioSource.PlayClipAtPoint(cannonsound[i], Camera.main.transform.position);
        
      
    }
}
