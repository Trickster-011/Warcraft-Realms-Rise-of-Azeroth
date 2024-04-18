using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public Text textObject;
    public string displayText;
    public float displayDuration = 5f;

    private void Start()
    {
        textObject.text = displayText;
        Invoke("HideText", displayDuration);
    }

    private void HideText()
    {
        textObject.text = "";
    }
}
