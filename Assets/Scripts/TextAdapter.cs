using UnityEngine;
using TMPro;

public class TextAdapter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpText;
    [SerializeField] private UnityEngine.UI.Text uiText;

    public string Text
    {
        get
        {
            if (tmpText != null)
                return tmpText.text;
            else if (uiText != null)
                return uiText.text;
            else
                return "";
        }
        set
        {
            if (tmpText != null)
                tmpText.text = value;
            else if (uiText != null)
                uiText.text = value;
        }
    }
}
