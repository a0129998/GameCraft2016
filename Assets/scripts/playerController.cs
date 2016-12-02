using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	private int x;
	private int y;
	private int move=-1;
	public boardManager bm;
	private int lower_x, lower_y, upper_x, upper_y;//the bounds for legal moves
	private int[,] moves = new int[2,4] { {0, 0, -1, 1}, {-1, 1, 0, 0}};//to determine the coords of the next move

	void Awake(){
		lower_x = -2;//TO CHANGE TO REFLECT THE ROWS AND COLS FROM boardManager
		upper_x = 2;
		lower_y = -2;
		upper_y = 2;
	}

	bool inRange(int nx, int ny){
		return nx <= upper_x && nx >= lower_x && ny <= upper_y && ny >= lower_y;
	}

	void makeMove(int moveIndx){
		x += moves[0, moveIndx];
		y += moves[1, moveIndx];
		switch (moveIndx) {
		case 0:
			this.transform.position += Vector3.up;
			break;
		case 1:
			this.transform.position += Vector3.down;
			break;
		case 2:
			this.transform.position += Vector3.left;
			break;
		case 3:
			this.transform.position += Vector3.right;
			break;
		}
	}

	void Update(){
		move = -1;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			move = 0;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			move = 1;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			move = 2;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			move = 3;
		}

		if(move > -1 && inRange(x+moves[0, move], y+moves[1, move])){
			makeMove (move);
			Debug.Log ("x = " + x + " y= " + y);
		}
	}
}
