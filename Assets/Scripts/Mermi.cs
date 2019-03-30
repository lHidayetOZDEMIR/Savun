using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mermi : MonoBehaviour
{
    AltinScript altinScript;
    EnemyControls enemyControls;
    Enemies enemies;
    ScoreScript scoreScript;
    Silah silah;
    Images images;
    public GameObject explosion;
    GameObject explosionGercek;
    void Start()
    {
        images = FindObjectOfType<Images>();
        scoreScript = FindObjectOfType<ScoreScript>();
        enemyControls = FindObjectOfType<EnemyControls>();
        silah = FindObjectOfType<Silah>();
        enemies = FindObjectOfType<Enemies>();
        altinScript = FindObjectOfType<AltinScript>();
    }
    void OnTriggerEnter2D(Collider2D nesne)
    {
        if (nesne.gameObject.tag == "Enemy" && enemies != null)
        {
            explosionGercek = Instantiate(explosion);
            explosionGercek.transform.SetParent(nesne.transform, false);
            explosionGercek.transform.position = nesne.transform.position;           
         /*    Instantiate(explosion,nesne.transform.position, Quaternion.identity).transform.SetParent(enemyControls.clons, false); */
            nesne.GetComponent<Enemies>().enemyCan -= silah.atisGucu;
            nesne.GetComponent<Enemies>().healthbar.value = nesne.GetComponent<Enemies>().enemyCan;
            if (nesne.GetComponent<Enemies>().enemyCan <= 0)
            {
                nesne.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                nesne.GetComponent<BoxCollider2D>().enabled = false;
                if (nesne.GetComponent<Enemies>().enemyHiz==2)
                {
                    nesne.GetComponent<Enemies>().animator.SetInteger("Die", 1);
                }
                else if(nesne.GetComponent<Enemies>().enemyHiz == 3)
                {
                    nesne.GetComponent<Enemies>().animator.SetInteger("Die", 2);
                }
                else nesne.GetComponent<Enemies>().animator.SetInteger("Die", 3);

                scoreScript.score++;
                altinScript.altinMiktari += nesne.GetComponent<Enemies>().altinMiktari;
                images.ButtonControl();
                altinScript.UpdateAltin();
                scoreScript.UpdateScore();
                enemyControls.yokOlanSayisi++;
                silah.sayac++;
                Destroy(nesne.gameObject,1f);
            }          
            Destroy(gameObject);
        } 
        if (nesne.gameObject.tag == "Sinir2")
        {
            Destroy(gameObject);
        }
    }
}