using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public GameObject redTile;
	public GameObject blueTile;
	public GameObject yellowTile;
	public GameObject greenTile;
	public GameObject tealTile;
	public GameObject tileParent;
	public int gridX = 3;
	public int gridY = 3;

	private GameObject[,] tiles;

	// Use this for initialization
	void Start () {
		tiles = new GameObject[gridX, gridY];
		resetMap ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void returnToMenu(){
		SceneManager.LoadScene ("MainMenuScene");
	}

	public void resetMap(){
		GetComponent<MouseController> ().resetGame ();

		GameObject tileToPlace = null;
		for(int x = 0; x < gridX; x++){
			for(int y = 0; y < gridY; y++){
				int temp = Random.Range (1, 6);

				if (tiles [x, y] != null)
					Destroy (tiles[x,y]);
				
				if (temp == 1 && MainMenuScript.colorNum >= 1) {
					tileToPlace = redTile;
				} else if (temp == 2 && MainMenuScript.colorNum >= 2) {
					tileToPlace = blueTile;
				} else if (temp == 3 && MainMenuScript.colorNum >= 3) {
					tileToPlace = yellowTile;
				} else if (temp == 4 && MainMenuScript.colorNum >= 4) {
					tileToPlace = greenTile;
				} else if (temp == 5 && MainMenuScript.colorNum >= 5) {
					tileToPlace = tealTile;
				} else {
					y--;
					continue;
				}

				tiles [x, y] = Instantiate (tileToPlace, new Vector3(x, 0 ,y), Quaternion.identity, tileParent.transform);
			}
		}
	}


}
