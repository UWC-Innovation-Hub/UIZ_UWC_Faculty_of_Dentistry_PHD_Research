using System;
using UnityEngine;

public class LoginUI : MonoBehaviour
{
    // Event to activate Main Canvas Group UI
    public event EventHandler<GameObject> OnLogin;
    
    public void Login()
    {
        OnLogin?.Invoke(this, gameObject);
    }
}
