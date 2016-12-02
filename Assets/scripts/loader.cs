using UnityEngine;
using System.Collections;

public class loader : MonoBehaviour {
	public GameManager gameManager;
	// Use this for initialization
	void Awake () {
		if (GameManager.instance == null) {
			Instantiate (gameManager);
			Debug.Log ("Instantiate game manager");
		}
	}

}
