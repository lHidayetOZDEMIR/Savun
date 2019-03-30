using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour {

    Silah silah;
    EnemyControls enemyControls;
    public float enemyCan, enemyHiz,enemyGuc,altinMiktari;
    public Sprite[] sprites;
    public Slider healthbar;
    public Animator animator;
 
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Start() {
        enemyControls = FindObjectOfType<EnemyControls>();
        silah = FindObjectOfType<Silah>();
    }
    void Update() {
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sinir")
        {
            Destroy(gameObject);
            enemyControls.yokOlanSayisi++;
            silah.can--;

            if (silah.can == 2) silah.canlar[2].enabled = false;
            else if (silah.can == 1) silah.canlar[1].enabled = false;
            else if (silah.can == 0) {
               silah.canlar[0].enabled = false;
                FindObjectOfType<SaveLoad>().Save();             
                // SceneManager.LoadScene(2);  
            }
        }
    }
}

