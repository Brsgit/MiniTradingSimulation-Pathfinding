using TMPro;
using UnityEngine;

public class PurseView : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private const string PURSE_TEXT = "Current Gold: ";

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateText(string text)
    {
        if(_text == null)
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }

        _text.text = PURSE_TEXT + text;
    }
}
