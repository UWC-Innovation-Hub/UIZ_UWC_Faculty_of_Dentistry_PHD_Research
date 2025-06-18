using System;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public event Action OnResultsClicked;

    public void ResultsClicked()
    {
        OnResultsClicked?.Invoke();
    }
}
