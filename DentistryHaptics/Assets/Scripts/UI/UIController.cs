using UnityEngine;

public class UIController : MonoBehaviour
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

    private void OnLoginEventReceived(GameObject loginUIGameObject)
    {
        loginUIGameObject.SetActive(false);
    }
}
