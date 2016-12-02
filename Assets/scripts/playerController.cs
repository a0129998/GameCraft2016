using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	private int x;
	private int y;

	void Update(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			this.transform.position += Vector3.up;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			this.transform.position += Vector3.down;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.transform.position += Vector3.left;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			this.transform.position += Vector3.right;
		}
	}
}
