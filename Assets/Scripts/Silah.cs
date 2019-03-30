using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Silah : MonoBehaviour {

    public GameObject mermi,mermiGercek;
    public Transform mermiSpawnPoint,canvas;
    public Image[] canlar;
    public float atisGucu,can,sayac,atisHizi;
    public Button fireButton;
    SoundControlScript soundControl;
    SaveLoad saveLoad;
    AltinScript altinScript;
    void Start()
    {
        altinScript = FindObjectOfType<AltinScript>();
        saveLoad = FindObjectOfType<SaveLoad>();
        soundControl = FindObjectOfType<SoundControlScript>();
        altinScript.UpdateAltin();
        //atisGucu = 1;
        //atisHizi = 1;
        saveLoad.atisGucu = atisGucu;
        saveLoad.atisHizi = atisHizi;
        saveLoad.Load();  
    }
    void FixedUpdate() 
    {
        if (sayac == 5)//-------BURASI ARTIK OLMAYACAK BİZ PARAYLA GÜC ALICAZ ------------
        {
            atisGucu += 1;
            sayac = 0;
        }
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
      //  gameObject.transform.position = new Vector2(0, hit.collider.gameObject.transform.position.y);
        if (Input.GetMouseButtonDown(0))//&& hit.collider.gameObject.tag == "AlanSinir"
        {
            if (hit.collider != null && hit.collider.gameObject.tag == "SlahPoint")
            {
                gameObject.transform.position = hit.transform.position;
            }
        }
   }
    public void Fire()
    {
        soundControl.Cal(1);
        //fireButton.GetComponent<Button>().interactable = false;
        mermiGercek = Instantiate(mermi);
        mermiGercek.transform.SetParent(canvas, false);
        mermiGercek.transform.position = mermiSpawnPoint.position;
        mermiGercek.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 10f, ForceMode2D.Impulse);    
        //Invoke("Aktif",atisHizi);
    }
    void Aktif()
    {
        fireButton.GetComponent<Button>().interactable = true;
    }
 }