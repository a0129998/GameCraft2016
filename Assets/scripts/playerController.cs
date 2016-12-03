using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	//private int move=-1;
	public GameManager gameManager;
	public AudioSource illegalMove;
	public AudioSource purrMove;
	public AudioSource playerLost;
	private int lower_x, lower_y, upper_x, upper_y;//the bounds for legal moves
	//private int[,] moves = new int[2,4] { {0, 0, -1, 1}, {-1, 1, 0, 0}};//to determine the coords of the next move
	private int[,] matrix;

	void Start(){
		matrix = GameManager.GetMatrix ();//load matrix from game manager
		lower_x = 0;
		upper_x = GameManager.GetX() - 1;
		lower_y = 0;
		upper_y = GameManager.GetY() - 1;
		//Debug.Log (upper_y);
	}

	bool inRange(int nx, int ny){
		return nx <= upper_x && nx >= lower_x && ny <= upper_y && ny >= lower_y;
	}

	void makeMove(int moveIndx){
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
	public 

	void Update(){
		int x = (int)this.transform.position.x;
		int y = (int)this.transform.position.y;
		//Debug.Log ("x = " + x + " y= " + y);
		int move = -1;
		bool canMakeMove = true;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			move = 0;
			canMakeMove = inRange (x, y + 1);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			move = 1;
			canMakeMove = inRange (x, y - 1);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			move = 2;
			canMakeMove = inRange(x - 1, y);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			move = 3;
			canMakeMove = inRange(x + 1, y);
		}

		if(move > -1 && canMakeMove){
			makeMove (move);
			updateGameManager ();
			purrMove.Play();
			//Debug.Log ("x = " + x + " y= " + y);
		}else if (!canMakeMove){
			illegalMove.Play ();
		}
		if (GameManager.PlayerLost ()) {
			Debug.Log ("playerlost");
			playerLost.Play ();
			this.transform.position = GameManager.GetInitialPlayerPosition ();
		}
	}

	void updateGameManager(){
		GameManager.UpdatePlayerPosition((int)this.transform.position.x, (int)this.transform.position.y);
	}

	public void ResetPosition(){
		this.transform.position = Vector3.zero;
	}
}
