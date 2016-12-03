using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiController : MonoBehaviour {

	public GameManager gameManager;
	public Image healthbar;
	
	// Update is called once per frame
	void Update () {
		healthbar.fillAmount = (float)GameManager.GetPlayerHealth () / 10;
	}
}
