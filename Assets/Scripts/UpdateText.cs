using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UpdateText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    [SerializeField] private string prefix;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateFromInt(int score)
    {
        _text.text = prefix + score;
    }
    public void UpdateFromString(string text)
    {
        _text.text = text;
    }
}
