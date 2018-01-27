using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScreenButtons : MonoBehaviour {

	public Text finalMessage;

	void Start(){
		finalMessage.text = "";
	}


	// get the information which message (dead/alive) from the previous scene
	public void ShowFinalMessage(string message){
		finalMessage.text = message;
	}

	// get the information which player from the previous scene
	public void RestartGame(int player){
		if(player == 1){
			SceneManager.LoadScene("Walking");
		} else{
			//TODO load scene for player 2
		}
	}

	public void MainMenu(){
		SceneManager.LoadScene("MainMenu");
	}

	public void ExitGame(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}
}
