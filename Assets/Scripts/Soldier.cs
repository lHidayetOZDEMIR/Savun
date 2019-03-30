using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Soldier : MonoBehaviour
{
    Enemies enemies;
    AltinScript altinScript;
    ScoreScript scoreScript;
    EnemyControls enemyControls;
    public Sprite[] sprites;
    Images images;
    Vector3 position;
    public Slider healthbar;
    public float soldierCan,soldierHiz,soldierGuc;
    public Animator animator;
    bool kontrol;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        images = FindObjectOfType<Images>();
        altinScript = FindObjectOfType<AltinScript>();
        scoreScript = FindObjectOfType<ScoreScript>();
        enemyControls = FindObjectOfType<EnemyControls>();
    }
    IEnumerator Attack(Collider2D col)
    {       
        while(kontrol)
        {
            kontrol = false;
            col.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            col.GetComponent<Enemies>().animator.SetBool("Attack", true);
            animator.SetBool("Attack", true);
            col.GetComponent<Enemies>().enemyCan -= soldierGuc;
            col.GetComponent<Enemies>().healthbar.value = col.GetComponent<Enemies>().enemyCan;
            soldierCan -= col.GetComponent<Enemies>().enemyGuc;
            healthbar.value = soldierCan;
            if (soldierCan<=0 || col.GetComponent<Enemies>().enemyCan<=0)
            {
                if (soldierCan <= 0)
                {
                    SoldierDie(col);   
                }
                if (col.GetComponent<Enemies>().enemyCan <= 0)
                {
                    EnemyDie(col);                   
                }
                break;
            }    
            yield return new WaitForSeconds(0.5f);
            kontrol = true;
        }
    }
    void SoldierDie(Collider2D col)
    {
        animator.SetBool("Die", true);
        Destroy(gameObject, 1f);
        col.GetComponent<Enemies>().animator.SetBool("Attack", false);
        col.GetComponent<Rigidbody2D>().velocity = Vector3.left * col.GetComponent<Enemies>().enemyHiz;
    }
    void EnemyDie(Collider2D col)/******************burdaki ölüm animasyonları daha güzel yazılabilir mi?*********************/
    {
        animator.SetBool("Attack", false);
        if (col.GetComponent<Enemies>().enemyHiz == 2)
        {
            col.GetComponent<Enemies>().animator.SetInteger("Die", 1);
        }
        else if (col.GetComponent<Enemies>().enemyHiz == 3)
        {
            col.GetComponent<Enemies>().animator.SetInteger("Die", 2);
        }
        else col.GetComponent<Enemies>().animator.SetInteger("Die", 3);
        enemyControls.yokOlanSayisi++;
        scoreScript.score++;
        images.ButtonControl();
        scoreScript.UpdateScore();
        altinScript.altinMiktari += col.GetComponent<Enemies>().altinMiktari;
        altinScript.UpdateAltin();
        Destroy(col.gameObject, 1f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Enemy")
        {        
            if (soldierCan > 0 && col.GetComponent<Enemies>().enemyCan > 0)
            { 
                kontrol = true;
                StartCoroutine(Attack(col));
            }
        }
    }
    //void OnTriggerStay2D(Collider2D col)
    //{      
    //    if (col.gameObject.tag == "Enemy")
    //    {            
    //        if (soldierCan > 0 && col.GetComponent<Enemies>().enemyCan > 0)
    //        {
    //            StartCoroutine(Attack(col));            
    //        }
    //        //Debug.Log("enemy can: " + col.GetComponent<Enemies>().enemyCan);
    //        //Debug.Log("soldier can: " + soldierCan);
    //        //if (soldierCan <= 0)
    //        //{
    //        //    SoldierDie(col);
    //        //}
    //        //if (col.GetComponent<Enemies>().enemyCan <= 0 )
    //        //{
    //        //    Debug.Log("canı 0");
    //        //    EnemyDie(col);
    //        //}
    //    }
    //} 
}