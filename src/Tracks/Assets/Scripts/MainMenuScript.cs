using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	public static int colorNum = 3;
	public GameObject mainMenuPanel;
	public GameObject gameStartPanel;
	public GameObject tutorialPanel;
	public GameObject activePanel;
	public Text colorCountText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	private void switchPanel(GameObject newPanel){
		activePanel.SetActive (false);
		newPanel.SetActive (true);
		activePanel = newPanel;
	}

	public void startGameButtonPress(){
		SceneManager.LoadScene ("GameScene");
	}

	public void setColorNum(int num){
		colorNum = num;
		colorCountText.text = "" + num;
	}

	public void playButtonPress(){
		switchPanel (gameStartPanel);
	}

	public void tutorialButtonPress(){
		switchPanel (tutorialPanel);
	}

	public void backButtonPress(){
		switchPanel (mainMenuPanel);
	}

	public void exitButtonPress(){
		Application.Quit();
	}


}
