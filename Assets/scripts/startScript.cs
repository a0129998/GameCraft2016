using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour {

	// Use this for initialization
	//public Canvas c;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			//c.enabled = false;
			SceneManager.LoadScene ("scene1", LoadSceneMode.Single);
		}
	}
}
