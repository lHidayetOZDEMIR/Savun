using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Images : MonoBehaviour {

    public Button buttonYeniCeri,buttonAvciEri,buttonKazikliEngel;
    public GameObject soldier;
    public Transform clons;
    public GameObject asker;
    SiperControl siperControl;
    ScoreScript scoreScript;
    void Start () {

        scoreScript = FindObjectOfType<ScoreScript>();
        siperControl = FindObjectOfType<SiperControl>();
        siperControl.SiperTrue(); 
    }
    public void ButtonControl()
    {
        if (scoreScript.score >= 3)
        {
            buttonYeniCeri.GetComponent<Button>().interactable = true;
            buttonAvciEri.GetComponent<Button>().interactable = true;
            buttonKazikliEngel.GetComponent<Button>().interactable = true;
        }
        else if (scoreScript.score >= 2)
        {
            buttonYeniCeri.GetComponent<Button>().interactable = true;
            buttonAvciEri.GetComponent<Button>().interactable = true;         
        }
        else if (scoreScript.score >= 1)
        {
            buttonYeniCeri.GetComponent<Button>().interactable = true;         
        }
    }
    public void ButtonControl2()
    {
        buttonYeniCeri.GetComponent<Button>().interactable = false;
        buttonAvciEri.GetComponent<Button>().interactable = false;
        buttonKazikliEngel.GetComponent<Button>().interactable = false;
    }
    public void YeniCeriUret()
    {
        asker = Instantiate(soldier);
        asker.GetComponent<Image>().sprite = asker.GetComponent<Soldier>().sprites[0];
        asker.GetComponent<Soldier>().animator.SetInteger("Idle", 1);
        asker.GetComponent<Soldier>().soldierCan = 24;
        asker.GetComponent<Soldier>().soldierGuc = 2;
        asker.GetComponent<Soldier>().healthbar.maxValue = asker.GetComponent<Soldier>().soldierCan;
        asker.GetComponent<Soldier>().healthbar.value = asker.GetComponent<Soldier>().soldierCan;      
        siperControl.SiperTrue();
        scoreScript.score -= 5;
        if (scoreScript.score <= 0)
        {
            scoreScript.score = 0;
        }
        scoreScript.UpdateScore();
        ButtonControl2();
    }
    public void AvciEriUret()
    {
        asker = Instantiate(soldier);
        asker.GetComponent<Image>().sprite = asker.GetComponent<Soldier>().sprites[1];
        asker.GetComponent<Soldier>().animator.SetInteger("Idle",2);
        asker.GetComponent<Soldier>().soldierCan = 4;
        asker.GetComponent<Soldier>().soldierGuc = 4;
        asker.GetComponent<Soldier>().healthbar.maxValue = asker.GetComponent<Soldier>().soldierCan;
        asker.GetComponent<Soldier>().healthbar.value = asker.GetComponent<Soldier>().soldierCan;
        siperControl.SiperTrue();
        scoreScript.score -= 10;
        if (scoreScript.score <= 0)
        {
            scoreScript.score = 0;
        }
        scoreScript.UpdateScore();
        ButtonControl2();
    }
    public void KazikliEngelUret()
    {
        asker = Instantiate(soldier);
        asker.GetComponent<Image>().sprite = asker.GetComponent<Soldier>().sprites[2];
        asker.GetComponent<Soldier>().soldierCan = 50;
        //  soldierGercek.GetComponent<Soldier>().soldierGuc = 2;
        asker.GetComponent<Soldier>().animator.SetInteger("Idle", 3);
        asker.GetComponent<Soldier>().healthbar.maxValue = asker.GetComponent<Soldier>().soldierCan;
        asker.GetComponent<Soldier>().healthbar.value = asker.GetComponent<Soldier>().soldierCan;
        siperControl.SiperTrue();
        scoreScript.score -= 15;
        if (scoreScript.score <= 0)
        {
            scoreScript.score = 0;
        }
        scoreScript.UpdateScore();
        ButtonControl2();
    }
}
