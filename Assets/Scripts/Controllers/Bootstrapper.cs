using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PositioningConfiguration positioningConfiguration;

    public void Awake()
    {
        Configurations.PositioningConfiguration = positioningConfiguration;
        SceneManager.LoadScene(1);
    }
}