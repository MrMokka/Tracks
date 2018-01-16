using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour {

	public Color lastColorUsed = Color.black;
	public GameObject player;
	public Color lastTileColor = Color.black;
	public float radius = 2f;
	public Text scoreText;
	public Image cantEnterImage;
	public int score = 0;

	private GameObject lastTileClicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonUp(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if(Physics.Raycast(ray, out hit)){
				if(hit.transform.tag == "Tile"){
					if(lastTileClicked != null){
						Collider[] cols = Physics.OverlapSphere (lastTileClicked.transform.position, radius);
						bool isNeightbour = false;
						for(int i = 0; i < cols.Length; i++){
							if (cols [i].gameObject == hit.transform.gameObject)
								isNeightbour = true;
						}
						if (isNeightbour == false) {
							print ("Tile is not neightbour");
							return;
						}
					}

					Color temp = hit.transform.gameObject.GetComponent<MeshRenderer> ().material.color;
					if(lastTileColor == Color.black){
						lastTileColor = temp;

					}
					if(lastColorUsed == temp){
						print("ERROR: You just changed from that color");
						return;
					}

					if (lastTileColor != temp) {
						lastColorUsed = lastTileColor;
						lastTileColor = temp;
						score += 10;
					} else {
						score += 1;
					}
					cantEnterImage.color = lastColorUsed;
					scoreText.text = "Score: " + score;
					lastTileClicked = hit.transform.gameObject;
					player.transform.position = hit.transform.position;
					hit.transform.gameObject.SetActive (false);
				}
			}
		}

	}


	public void resetGame(){
		score = 0;
		scoreText.text = "Score: 0";
		lastColorUsed = Color.black;
		lastTileColor = Color.black;
		lastTileClicked = null;
		cantEnterImage.color = Color.black;
		player.transform.position = new Vector3 (100f, 0f, 100f);
	}

}
