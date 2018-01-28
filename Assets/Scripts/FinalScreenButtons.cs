using System.Collections;
using System.Collections.Generic;
using Constants;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScreenButtons : MonoBehaviour
{
    public Button RestartButton;
    public Button MainMenuButton;
    public Button ExitButton;

    public Text finalMessage;

    void Start()
    {
        finalMessage.text = "";
        ShowFinalMessage();

        RestartButton.onClick.AddListener(RestartGame);
        MainMenuButton.onClick.AddListener(MainMenu);
        ExitButton.onClick.AddListener(ExitGame);
    }


    // get the information which message (dead/alive) from the previous scene
    public void ShowFinalMessage()
    {
        finalMessage.text = PlayerPrefs.GetString(PlayerPrefConstants.EndText);
    }

    // get the information which player from the previous scene
    public void RestartGame()
    {
        PlayerType playerType = (PlayerType) PlayerPrefs.GetInt(PlayerPrefConstants.PlayerId);

        if (playerType == PlayerType.Roomie)
        {
            SceneManager.LoadScene("Room_walls_noceiling");
        }
        else
        {
            SceneManager.LoadScene("GuideScene");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}