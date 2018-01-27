using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	public void StartGamePlayerOne() {
        SceneManager.LoadScene(1);
	}

	public void StartGamePlayerTwo() {

	}

	public void OpenInstructions() {

	}

	public void ExitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
