using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodController : MonoBehaviour {

	private BoxCollider2D bc2d;
	private SpriteRenderer sr;
	public GameManager gameManager;
	public AudioSource chewFood;
	
	// Update is called once per frame
	void Update () {
		bc2d = this.GetComponent<BoxCollider2D> ();
		bc2d.isTrigger = true;
		sr = this.GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			GameManager.AddPlayerHealth ();
			chewFood.Play ();
			sr.enabled = false;
			Debug.Log ("added health");
		}
	}
}
