using UnityEngine;

public class ResultsUI : MonoBehaviour
{
    [SerializeField] private MainMenuUI mainMenuUI;
    [SerializeField] private GameObject resultsUICanvas;

    private void Start()
    {
        if (mainMenuUI == null)
            Debug.LogError("MainMenuUI not assigned");

        if (resultsUICanvas == null)
            Debug.LogError("ResultsUICanvas not assigned");
    }

    private void OnEnable()
    {
        mainMenuUI.OnResultsClicked += ResultsUIActivation;
    }

    private void OnDisable()
    {
        mainMenuUI.OnResultsClicked -= ResultsUIActivation;
    }

    private void ResultsUIActivation()
    {
        if (resultsUICanvas.activeSelf)
            resultsUICanvas.SetActive(false);
        else
            resultsUICanvas.SetActive(true);
    }
}
