using Constants;
using Events;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image fadeOutImage;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private PlayerType playerType;

    private float currentTimer;
    private bool isFading;

    private void Update()
    {
        if (isFading)
        {
            currentTimer += Time.deltaTime;
            fadeOutImage.color = new Color(fadeOutImage.color.r, fadeOutImage.color.g, fadeOutImage.color.b,
                currentTimer / fadeOutTime);

            if (currentTimer >= fadeOutTime)
            {
                PlayerPrefs.SetInt(PlayerPrefConstants.PlayerId, (int)playerType);
                PlayerPrefs.SetString(PlayerPrefConstants.EndText, "You weren't able to escape!");
                SceneManager.LoadScene("FinalScreen");
            }
        }
    }

    private EventManager eventManager = EventManager.Instance;

    public void Awake()
    {
        eventManager.RegisterForEvent(EventTypes.TimeOut, OnTimeOut);
    }

    private void OnTimeOut(IEvent evtData)
    {
        isFading = true;
    }
}