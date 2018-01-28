using Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PositioningConfiguration positioningConfiguration;
    [SerializeField] private TriggerConfiguration triggerConfiguration;

    public void Awake()
    {
        Configurations.PositioningConfiguration = positioningConfiguration;
        Configurations.TriggerConfiguration = triggerConfiguration;
        SceneManager.LoadScene("MainMenu");
    }
}