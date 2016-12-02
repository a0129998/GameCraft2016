using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public TextAsset[] textAsset; //contains the matrix for each level
	public boardManager bm;
	private int[,] currMatrix;
	private int x;
	private int y;
	private int currLevel = 0;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

		//make sure len(t) <= currlevel
		initMatrix (currLevel);
		bm.BoardInit (currMatrix);
	}


	void initMatrix(int level){
		StringReader strReader = new StringReader (textAsset[currLevel].text);
		string[] xy = strReader.ReadLine ().Split(' ');
		this.x = Int32.Parse (xy [0]);
		this.y = Int32.Parse (xy [1]);
		this.currMatrix = new int[x, y];
		//Debug.Log ("x is " + x + " y is " + y);
		for (int i = 0; i < x; i++) {
			string[] currLine = strReader.ReadLine ().Split(' ');
			for (int j = 0; j < y; j++) {
				currMatrix [i, j] = Int32.Parse (currLine[j]);
				//Debug.Log ("i is " + i + " j is " + j);
			}
		}
	}
}
