using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour {
	private Camera cam;
	// Use this for initialization
	void Start () {
		float targetaspect = 5.0f / 4.0f;
		float windowaspect = (float)Screen.width / (float)Screen.height;
		float scaleheight = windowaspect / targetaspect;
		cam = GetComponent<Camera> ();
		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{  
			Rect rect = cam.rect;

			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;

			cam.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;

			Rect rect = cam.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			cam.rect = rect;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
