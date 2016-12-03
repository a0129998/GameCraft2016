using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public TextAsset[] textAsset; //contains the matrix for each level
	public boardManager bm;
	//private static AudioSource playerWon;
	//private static AudioSource playerLost;
	//public audioContainer ac;
	private static int[,] currMatrix;
	private static int x;
	private static int y;
	private static int currLevel;
	private static int[] playerPosition;
	private static int[] playerInitialPosition;
	private static int playerHealth;
	private static GameObject player;
	private static bool lostP;

	void Awake(){
		
		if (instance == null) {
			//Debug.Log ("awake at game manager");
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		currLevel = 0;
		Debug.Log ("level " + currLevel);
		//make sure len(t) <= currlevel
		initGame(currLevel);
		//playerWon = ac.GetWinSound ();
		//playerLost = ac.GetLoseSound ();
		//this.x = currMatrix.GetLength(0);
		//this.y = currMatrix.GetLength (1);
		//Debug.Log (x);
	}

	public void initGame(int level){
		Debug.Log ("initgame at level " + level);
		initMatrix (currLevel);
		bm.BoardInit (currMatrix);
		playerHealth = 10;
		player = GameObject.FindWithTag("Player");
		lostP = false;
	}


	void initMatrix(int level){
		
		StringReader strReader = new StringReader (textAsset[currLevel].text);
		string[] xy = strReader.ReadLine ().Split(' ');
		x = Int32.Parse (xy [0]);
		y = Int32.Parse (xy [1]);
		currMatrix = new int[x, y];
		//Debug.Log ("x is " + x + " y is " + y);
		for (int i = 0; i < x; i++) {
			string[] currLine = strReader.ReadLine ().Split(' ');
			for (int j = 0; j < y; j++) {
				currMatrix [i, j] = Int32.Parse (currLine[j]);
				if (currMatrix [i, j] == 1) {
					//found player
					playerPosition = new int[2]{i, j};
					playerInitialPosition = playerPosition;
				}
				//Debug.Log ("i is " + i + " j is " + j);
			}
		}
	}

	public static int GetX(){
		//Debug.Log ("x is " + x);
		return x;

	}

	public static int GetY(){
		return y;
	}

	public static int[,] GetMatrix(){
		return currMatrix;
	}

	public static int GetLevel(){
		return currLevel;
	}

	public static void UpdatePlayerPosition(int nX, int nY){
		int currX = playerPosition[0];
		int currY = playerPosition[1];

		playerPosition [0] = nX;
		playerPosition [1] = nY;
		currMatrix [currX, currY] = 0;
		currMatrix [nX, nY] = 1;
	}

	public static int[] GetPlayerPosition(){
		return playerPosition;
	}

	public static bool CanEnter(int cx, int cy){
		if (cx < x && cx >= 0 && cy < y && cy >= 0) {
			return currMatrix [cx, cy] == 0;
		}
		return false;
	}

	public static void MinusPlayerHealth(){
		if (playerHealth == 1) {
			//game over
			Lose();
		}else{
			playerHealth--;
		}
		//Debug.Log ("player health: " + playerHealth);
	}

	public static int GetPlayerHealth(){
		return playerHealth;
	}

	public static void AddPlayerHealth(){
		if (playerHealth < 10) {
			playerHealth++;
		}
	}

	public static void ResetPlayerHealth(){
		playerHealth = 10;
		lostP = false;
	}

	public static void Win(){
		//todo
		//playerWon.enabled = true;
		//playerWon.Play();
		Debug.Log("player won");
		currLevel++;
	}

	public static void Lose(){
		//todo
		//playerLost.Play();
		lostP = true;
		SceneManager.LoadSceneAsync ("loseScene", LoadSceneMode.Single);
		currLevel = 0;
		Debug.Log("player lost");
	}

	public static bool PlayerLost(){
		return lostP;
	}


	public static Vector3 GetInitialPlayerPosition(){
		return new Vector3 (playerInitialPosition [0], playerInitialPosition [1]);
	}

	public static void ResetLocation(int nx, int ny){
		currMatrix [nx, ny] = 0;
	}


}
