using UnityEngine;

public class LogComponent : MonoBehaviour
{
    [SerializeField] private TextMesh logTextField;
    [SerializeField] private Color positiveColor;
    [SerializeField] private Color negativeColor;

    public void DisplayText(string textToDisplay, bool isPositive)
    {
        logTextField.text = textToDisplay;
        logTextField.color = isPositive ? positiveColor : negativeColor;
    }
}
