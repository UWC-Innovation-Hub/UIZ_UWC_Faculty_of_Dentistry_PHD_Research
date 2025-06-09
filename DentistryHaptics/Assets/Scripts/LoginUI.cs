using System;
using UnityEngine;

public class LoginUI : MonoBehaviour
{
    // Event to activate Main Canvas Group UI
    private event EventHandler OnLogin;
    
    public void Login()
    {
        OnLogin?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(false);
    }
}
