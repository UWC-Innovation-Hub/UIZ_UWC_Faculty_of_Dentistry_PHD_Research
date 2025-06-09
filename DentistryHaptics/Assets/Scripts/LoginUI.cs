using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

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
