using UnityEngine;

public class LogComponent : MonoBehaviour
{
    [SerializeField] private TextMesh logTextField;
    [SerializeField] private MeshRenderer textFieldRenderer;
    [SerializeField] private Material positiveMaterial;
    [SerializeField] private Material negativeMaterial;

    public void DisplayText(string textToDisplay, bool isPositive)
    {
        logTextField.text = textToDisplay;
        textFieldRenderer.material = isPositive ? positiveMaterial : negativeMaterial;
    }
}
