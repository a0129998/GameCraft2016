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

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List <Vector3> ();

	void InitList(int[,] matrix){
		rows = matrix.GetLength (0);
		cols = matrix.GetLength (1);

		gridPositions.Clear ();//clear all previous grid positions

		for (int x = 0; x < cols; x++) {
			for (int y = 0; y < rows; y++) {
				gridPositions.Add (new Vector3 (x, y, 0f));
			}
		}
	}

	void BoardSetup(){
		boardHolder = new GameObject ("Board").transform;

		for (int x = 0; x < cols; x++) {
			for (int y = 0; y < rows; y++) {
				GameObject toInstantiate = backgroundTiles [Random.Range (0, backgroundTiles.Length)];
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
				Vector3 originalScale = instance.transform.localScale;
				instance.transform.localScale = originalScale / 3 - new Vector3(0.1f, 0.1f, 0f);
			}
		}
	}

	public void BoardInit(int[,] m){
		InitList (m);
		BoardSetup ();
	}
}
