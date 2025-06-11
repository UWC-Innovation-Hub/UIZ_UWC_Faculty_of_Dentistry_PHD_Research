using System;
using UnityEngine;

public class LoginUI : MonoBehaviour
{
    public event Action OnLogin; 
    public void Login()
    {
        OnLogin?.Invoke();
    }
}
