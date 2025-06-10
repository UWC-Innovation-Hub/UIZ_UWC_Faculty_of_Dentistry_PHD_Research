using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private LoginUI LoginUI;

    private void OnEnable()
    {
        if (LoginUI == null)
        {
            Debug.LogError("Login UI reference is null in UIController!", this);
            return;
        }
        LoginUI.OnLogin += OnLoginButtonPressed;
    }

    private void OnDisable()
    {
        if (LoginUI != null)
            LoginUI.OnLogin -= OnLoginButtonPressed;
    }

    private void OnLoginButtonPressed(object sender, GameObject loginUIGameObject)
    {
        if (loginUIGameObject != null)
            return;
        
        loginUIGameObject.SetActive(false);
    }
}
