using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	public void StartGamePlayerOne() {
        SceneManager.LoadScene("Room_walls_noceiling");
	}

	public void StartGamePlayerTwo() {
	    SceneManager.LoadScene("GuideScene");
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
