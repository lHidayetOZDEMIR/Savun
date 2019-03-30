using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	void Start () {
       Invoke("Die",1f);
	}
	void Die () {
        Destroy(gameObject);
	}
}
