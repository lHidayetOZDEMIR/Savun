using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyControls : MonoBehaviour {

    Enemies enemies;
    GameObject piyade, mizrakliPiyade, mizrakliSuvari, venedikSovalye;
    public Transform clons;
    public Transform[] enemySpawnPoint;
  //  public List<GameObject> enemiesList;
    public GameObject enemy, panel1, panel2;
    public int  yokOlanSayisi;
    float rndSprite,rndPoint;
    public int wave, yol,piyadeAdet,mizrakliPiyadeAdet,mizrakliSuvariAdet,venedikSovalyeAdet,toplamAdet;
    bool kontrol,kontrol2,kontrol3,kontrol4;
    void Start () {
        wave = 1;
        kontrol = true;
        kontrol2 = true;
        kontrol3 = true;
        kontrol4 = true;
        Uret();
        panel1.GetComponent<GameObject>();

    }
	void Update () {

        if (yokOlanSayisi == toplamAdet)
        {
            wave++;
         //   enemiesList.Clear();
           // uretimSayisi += 5;
            yokOlanSayisi = 0;
            toplamAdet = 0;
            Uret();
        }
    }
    public void PanelControl(int yol)
    {
        if (yol==3)
        {
            panel1.SetActive(true);
            panel2.SetActive(true);
        }
        else
        {
            panel1.SetActive(false);
            panel2.SetActive(false);    
        }
    }
    IEnumerator PiyadeUret()
    {
        while (kontrol && piyadeAdet > 0)
        {
            kontrol = false;
            piyade = Instantiate(enemy);
            piyade.transform.SetParent(clons, false);
            piyade.GetComponent<Image>().sprite = piyade.GetComponent<Enemies>().sprites[0];
            piyade.GetComponent<Enemies>().enemyCan = 10;
            piyade.GetComponent<Enemies>().enemyHiz = 4f;
            piyade.GetComponent<Enemies>().enemyGuc = 5;
            piyade.GetComponent<Enemies>().altinMiktari = 1;
            piyade.GetComponent<Enemies>().healthbar.maxValue = piyade.GetComponent<Enemies>().enemyCan;
            piyade.GetComponent<Enemies>().healthbar.value = piyade.GetComponent<Enemies>().enemyCan;
            piyade.GetComponent<Rigidbody2D>().velocity = Vector3.left * piyade.GetComponent<Enemies>().enemyHiz;
            piyade.GetComponent<Enemies>().animator.SetInteger("Run1", 1);
            rndPoint = Random.Range(0, yol);
            piyade.transform.position = enemySpawnPoint[2].position;
            piyadeAdet--;
            toplamAdet++;
            yield return new WaitForSeconds(1);
            kontrol = true;
        }
    }
  

    IEnumerator MizrakliPiyadeUret()
    {
        while (kontrol2 && mizrakliPiyadeAdet>0)
        {
            kontrol2 = false;
            mizrakliPiyade = Instantiate(enemy);
            mizrakliPiyade.transform.SetParent(clons, false);
            mizrakliPiyade.GetComponent<Image>().sprite = mizrakliPiyade.GetComponent<Enemies>().sprites[1];
            mizrakliPiyade.GetComponent<Enemies>().enemyCan = 13;
            mizrakliPiyade.GetComponent<Enemies>().enemyHiz = 3f;
            mizrakliPiyade.GetComponent<Enemies>().enemyGuc = 8;
            mizrakliPiyade.GetComponent<Enemies>().altinMiktari = 1;
            mizrakliPiyade.GetComponent<Enemies>().healthbar.maxValue = mizrakliPiyade.GetComponent<Enemies>().enemyCan;
            mizrakliPiyade.GetComponent<Enemies>().healthbar.value = mizrakliPiyade.GetComponent<Enemies>().enemyCan;

            mizrakliPiyade.GetComponent<Rigidbody2D>().velocity = Vector3.left * 3;
            
mizrakliPiyade.GetComponent<Enemies>().animator.SetInteger("Run1", 2);
            rndPoint = Random.Range(0, yol);
            mizrakliPiyade.transform.position = enemySpawnPoint[2].position;
            mizrakliPiyadeAdet--;
            toplamAdet++;
            yield return new WaitForSeconds(1);
            kontrol2 = true;
        }
    }
    //IEnumerator MizrakliSuvariUret()
    // {
    //     while (kontrol3 && mizrakliSuvariAdet > 0)
    //     {
    //         kontrol3 = false;
    //         mizrakliSuvari = Instantiate(enemy);
    //         mizrakliSuvari.transform.SetParent(clons, false);
    //         mizrakliSuvari.GetComponent<Image>().sprite = mizrakliSuvari.GetComponent<Enemies>().sprites[0];
    //         mizrakliSuvari.GetComponent<Enemies>().enemyCan = 35;
    //         mizrakliSuvari.GetComponent<Enemies>().enemyHiz = 2f;
    //         mizrakliSuvari.GetComponent<Enemies>().enemyGuc = 15;
    //         mizrakliSuvari.GetComponent<Enemies>().altinMiktari = 1;
    //         mizrakliSuvari.GetComponent<Enemies>().healthbar.maxValue = mizrakliSuvari.GetComponent<Enemies>().enemyCan;
    //         mizrakliSuvari.GetComponent<Enemies>().healthbar.value = mizrakliSuvari.GetComponent<Enemies>().enemyCan;
    //         mizrakliSuvari.GetComponent<Rigidbody2D>().velocity = Vector3.left * mizrakliSuvari.GetComponent<Enemies>().enemyHiz;
    //         mizrakliSuvari.GetComponent<Enemies>().animator.SetInteger("Run1", 3);
    //         rndPoint = Random.Range(0, yol);
    //         mizrakliSuvari.transform.position = enemySpawnPoint[(int)rndPoint].position;
    //         mizrakliSuvariAdet--;
    //        toplamAdet++;
   //         yield return new WaitForSeconds(1);
   //         kontrol3 = true;
   //     }
   // }
   // IEnumerator VenedikSovalyeUret()
   // {
   //     while (kontrol4 && mizrakliSuvariAdet > 0)
   //     {
   //         kontrol4 = false;
   //         venedikSovalye = Instantiate(enemy);
   //         venedikSovalye.transform.SetParent(clons, false);
   //         venedikSovalye.GetComponent<Image>().sprite = venedikSovalye.GetComponent<Enemies>().sprites[0];
   //         venedikSovalye.GetComponent<Enemies>().enemyCan = 5;
   //         venedikSovalye.GetComponent<Enemies>().enemyHiz = 1f;
   //         venedikSovalye.GetComponent<Enemies>().enemyGuc = 5;
   //         venedikSovalye.GetComponent<Enemies>().altinMiktari = 1;
   //         venedikSovalye.GetComponent<Enemies>().healthbar.maxValue = venedikSovalye.GetComponent<Enemies>().enemyCan;
   //         venedikSovalye.GetComponent<Enemies>().healthbar.value = venedikSovalye.GetComponent<Enemies>().enemyCan;
   //         venedikSovalye.GetComponent<Rigidbody2D>().velocity = Vector3.left * venedikSovalye.GetComponent<Enemies>().enemyHiz;
   //         venedikSovalye.GetComponent<Enemies>().animator.SetInteger("Run1", 1);
   //         rndPoint = Random.Range(0, yol);
   //         venedikSovalye.transform.position = enemySpawnPoint[(int)rndPoint].position;
   //         venedikSovalyeAdet--;
   //         toplamAdet++;
   //         yield return new WaitForSeconds(1);
   //         kontrol4 = true;
   //     }
   // }
    public void Uret()
    {
        if (wave==1)
        {
            yol = 5;
            PanelControl(yol);
            piyadeAdet = 1;
            StartCoroutine(PiyadeUret());
            mizrakliPiyadeAdet = 1;
            StartCoroutine(MizrakliPiyadeUret());
        }
        else if (wave==2)
        {
            yol = 3;
            PanelControl(yol);
            piyadeAdet = 1;
            StartCoroutine(PiyadeUret());
            mizrakliPiyadeAdet = 1;
            StartCoroutine(MizrakliPiyadeUret());

        }
        else if (wave>=3)
        {
            yol = 5;
            PanelControl(yol);  
            piyadeAdet = 1;
            StartCoroutine(PiyadeUret());
            mizrakliPiyadeAdet = 1;
            StartCoroutine(MizrakliPiyadeUret());
        }
        //for (int i = 0; i < uretimSayisi; i++)
        //{
        //    rndSprite = Random.Range(0, 2);
        //    rndPoint = Random.Range(0,5);
        //    enemiesList.Add(Instantiate(enemy));
        //    enemiesList[i].transform.SetParent(clons, false);
        //    enemiesList[i].GetComponent<Image>().sprite = enemiesList[i].GetComponent<Enemies>().sprites[(int)rndSprite];

        //    if (enemiesList[i].GetComponent<Image>().sprite == enemiesList[i].GetComponent<Enemies>().sprites[0])
        //    {
        //        enemiesList[i].GetComponent<Enemies>().enemyCan = 5;
        //        enemiesList[i].GetComponent<Enemies>().enemyHiz = 2f;
        //        enemiesList[i].GetComponent<Enemies>().enemyGuc = 5;
        //        enemiesList[i].GetComponent<Enemies>().altinMiktari = 1;
        //        enemiesList[i].GetComponent<Enemies>().healthbar.maxValue = enemiesList[i].GetComponent<Enemies>().enemyCan;
        //        enemiesList[i].GetComponent<Enemies>().healthbar.value = enemiesList[i].GetComponent<Enemies>().enemyCan;
        //        enemiesList[i].GetComponent<Rigidbody2D>().velocity = Vector3.left * enemiesList[i].GetComponent<Enemies>().enemyHiz;
        //        enemiesList[i].GetComponent<Enemies>().animator.SetInteger("Run1", 1);
        //    }
        //    else if (enemiesList[i].GetComponent<Image>().sprite == enemiesList[i].GetComponent<Enemies>().sprites[1])
        //    {
        //        enemiesList[i].GetComponent<Enemies>().enemyCan = 5;
        //        enemiesList[i].GetComponent<Enemies>().enemyHiz = 3f;
        //        enemiesList[i].GetComponent<Enemies>().enemyGuc = 8;
        //        enemiesList[i].GetComponent<Enemies>().altinMiktari = 2;
        //        enemiesList[i].GetComponent<Enemies>().healthbar.maxValue = enemiesList[i].GetComponent<Enemies>().enemyCan;
        //        enemiesList[i].GetComponent<Enemies>().healthbar.value = enemiesList[i].GetComponent<Enemies>().enemyCan;
        //        enemiesList[i].GetComponent<Rigidbody2D>().velocity = Vector3.left * enemiesList[i].GetComponent<Enemies>().enemyHiz;
        //        enemiesList[i].GetComponent<Enemies>().animator.SetInteger("Run1", 2);
        //    }
        //    enemiesList[i].transform.position = enemySpawnPoint[(int)rndPoint].position + new Vector3(i * 3f, 0f);
        //    if (wave == 3)
        //    {
        //        enemiesList[i].GetComponent<Image>().sprite = enemiesList[i].GetComponent<Enemies>().sprites[2];
        //        enemiesList[i].GetComponent<Enemies>().enemyCan = 100;
        //        enemiesList[i].GetComponent<Enemies>().enemyHiz = 1f;
        //        enemiesList[i].GetComponent<Enemies>().enemyGuc = 25;
        //        enemiesList[i].GetComponent<Enemies>().healthbar.maxValue = enemiesList[i].GetComponent<Enemies>().enemyCan;
        //        enemiesList[i].GetComponent<Enemies>().healthbar.value = enemiesList[i].GetComponent<Enemies>().enemyCan;
        //        enemiesList[i].GetComponent<Rigidbody2D>().velocity = Vector3.left * enemiesList[i].GetComponent<Enemies>().enemyHiz;
        //        enemiesList[i].GetComponent<Enemies>().animator.SetInteger("Run1", 3);
        //        enemiesList[i].transform.position = enemySpawnPoint[1].position + new Vector3(i * 3f, 0f);
        //        wave++;
        //    }
        //}
    }
}


