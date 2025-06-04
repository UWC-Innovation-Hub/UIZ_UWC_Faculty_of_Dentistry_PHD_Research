using TMPro;
using UnityEngine;

public class UITest : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    public void UpdateText()
    {
        textMeshProUGUI.text = $"Hello world";
    }
}
