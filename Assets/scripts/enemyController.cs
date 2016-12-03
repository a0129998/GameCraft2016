using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour {

	private int x; //position x
	private int y; //position y
	private int currLevel;
	private int[] followChance;
	public GameManager gameManager;
	public float timeToMove;
	private float timeFromStart;
	public AudioSource scratchSound;

	//private int lower_x, lower_y, upper_x, upper_y;
	// Use this for initialization
	void Start () {
		x = (int)this.transform.position.x;
		y = (int)this.transform.position.y;
		currLevel = GameManager.GetLevel ();
		followChance = new int[5]{ 3, 5, 6, 7, 8 };//random number from 1 to 10, smaller - follow
		timeFromStart = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		int[] playerPosition = GameManager.GetPlayerPosition ();

		timeFromStart += Time.deltaTime;
		if (timeFromStart > timeToMove) {
			timeFromStart = 0f;
			move ();
			//Debug.Log ("fat cat moved");
			if (canScratch (playerPosition [0], playerPosition [1])) {
				//scratch
				scratch();
			}
		}
	}

	private bool canScratch(int px, int py){
		return (px == x && Mathf.Abs (y - py) <= 1) || (py == y && Mathf.Abs (x - px) <= 1);
	}

	private void scratch(){
		GameManager.MinusPlayerHealth();
		scratchSound.Play ();
		//Debug.Log ("scratched");
	}

	private void move(){
		int[] playerPosition = GameManager.GetPlayerPosition ();
		bool follow = Random.Range (0, 10) < followChance[currLevel];

		if (follow) {
			moveTowardsPlayer (playerPosition [0], playerPosition [1]);
		} else {
			moveRandom ();
		}
	}

	private void moveTowardsPlayer(int px, int py){
		int move = Random.Range (0, 1);

		switch (move) {
		case 0:
			if (px < x) {
				moveCat (x - 1, y);
			} else {
				moveCat (x + 1, y);
			}
			break;
		case 1:
			if (py < y) {
				moveCat (x, y - 1);
			} else {
				moveCat (x, y + 1);
			}
			break;
		}
	}

	private void moveRandom(){
		
		int newPos = Random.Range (0, 4);//up down left right
		if (newPos == 0 && GameManager.CanEnter (x, y + 1)) {
			this.transform.position += Vector3.up;
		} else if (newPos == 1 && GameManager.CanEnter (x, y - 1)) {
			this.transform.position += Vector3.down;
		} else if (newPos == 2 && GameManager.CanEnter (x - 1, y)) {
			this.transform.position += Vector3.left;
		} else if (newPos == 3 && GameManager.CanEnter (x + 1, y)) {
			this.transform.position += Vector3.right;
		} else {
			//stuck
		}

		x = (int)this.transform.position.x;
		y = (int)this.transform.position.y;//update position for next movement
	}

	private void moveCat(int nX, int nY){
		if (GameManager.CanEnter (nX, nY)) {
			this.transform.position = new Vector3 ((float)nX, (float)nY);
		}
		x = (int)this.transform.position.x;
		y = (int)this.transform.position.y;//update position for next movement
	}

}
