using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private LoginUI LoginUI;

    private void Start()
    {
        if (LoginUI == null)
            Debug.LogError("Login UI is null");

        LoginUI.OnLogin += OnLoginButtonPressed;
    }

    private void OnLoginButtonPressed(object sender, GameObject loginUIGameObject)
    {
        loginUIGameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        LoginUI.OnLogin -= OnLoginButtonPressed;
    }
}
