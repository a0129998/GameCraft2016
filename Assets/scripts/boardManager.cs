using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class boardManager : MonoBehaviour {

	public GameObject[] backgroundTiles;
	public GameObject[] foodTiles;
	public GameObject[] enemyCats;
	public GameObject playerCat;
	public GameObject exit;
	private int rows;
	private int cols;
	private int[,] M;
	private Transform boardHolder;
	private List <Vector3> gridPositions = new List <Vector3> ();

	void InitList(int[,] matrix){
		M = matrix;
		rows = matrix.GetLength (0);
		cols = matrix.GetLength (1);

		gridPositions.Clear ();//clear all previous grid positions

		for (int x = 0; x < cols; x++) {
			for (int y = 0; y < rows; y++) {
				gridPositions.Add (new Vector3 (x, y, 0f));
			}
		}
	}

	int getRows(){
		return rows;
	}

	int getCols(){
		return cols;
	}

	void BoardSetup(){//normal tile - 0, player cat - 1, enemy cat - 2, food - 3
		//Destroy(GameObject.Find("Board"));
		if(GameObject.Find("Board") != null){
			destoryBoard ();
		}

		boardHolder = new GameObject ("Board").transform;

		for (int x = 0; x < cols; x++) {
			for (int y = 0; y < rows; y++) {
				GameObject toInstantiate = null;
				switch (M [x, y]) {
				case 0:
					toInstantiate = getBackGround ();
					break;
				case 1:
					toInstantiate = playerCat;
					break;
				case 2:
					toInstantiate = getEnemyCat ();
					break;
				case 3:
					toInstantiate = getFoodTile ();
					break;
				case 4:
					toInstantiate = exit;
					break;
				}
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
			}
		}
	}

	public void BoardInit(int[,] m){
		InitList (m);
		BoardSetup ();
	}

	private GameObject getBackGround(){
		return backgroundTiles [Random.Range (0, backgroundTiles.Length)];
	}

	private GameObject getEnemyCat(){
		return enemyCats [Random.Range (0, enemyCats.Length)];
	}

	private GameObject getFoodTile(){
		return foodTiles [Random.Range (0, foodTiles.Length)];
	}

	private void destoryBoard(){
		Destroy (GameObject.Find ("Board"));
	}
}
