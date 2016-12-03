using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioContainer : MonoBehaviour {


	public AudioSource winSound;
	public AudioSource loseSound;
	// Use this for initialization
	public AudioSource GetWinSound(){
		//winSound.enabled = true;
		return winSound;
	}

	public AudioSource GetLoseSound(){
		//loseSound.enabled = true;
		return loseSound;
	}
}
