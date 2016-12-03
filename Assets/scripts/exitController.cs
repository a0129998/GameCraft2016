using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitController : MonoBehaviour {
	private CircleCollider2D bc2d;
	public AudioSource winSound;
	public GameManager gameManager;
	// Use this for initialization
	void Start(){
		bc2d = this.GetComponent<CircleCollider2D> ();
		bc2d.isTrigger = true;
		//Debug.Log ("exit start");
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("trigger win");
		if (other.CompareTag ("Player")) {
			GameManager.Win ();

			winSound.Play ();
			Debug.Log ("trigger win");
			if (GameManager.GetLevel () < 3) {
				//Destroy (GameObject.Find ("Board"));
				SceneManager.LoadSceneAsync ("scene" + (GameManager.GetLevel() + 1), LoadSceneMode.Single);
				//gameManager.initGame (GameManager.GetLevel ());
			} else {
				// show ending
				SceneManager.LoadSceneAsync("winScene", LoadSceneMode.Single);
			}
		}
	}
}
