using UnityEngine;

public class MainCanvasGroupUI : MonoBehaviour
{
    [Header("Event Channel")]
    [SerializeField] private HomeSceneUIEventChannelSO homeSceneUIEventChannelSO;

    private void OnEnable()
    {
        homeSceneUIEventChannelSO.OnLoginEventRaised += OnLoginEventReceived;
    }

    private void OnDisable()
    {
        homeSceneUIEventChannelSO.OnLoginEventRaised -= OnLoginEventReceived;
    }

    private void OnLoginEventReceived(GameObject obj)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
