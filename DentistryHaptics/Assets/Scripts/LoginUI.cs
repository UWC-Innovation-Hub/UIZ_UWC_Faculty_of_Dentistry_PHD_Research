using System;
using UnityEngine;

public class LoginUI : MonoBehaviour
{
    [Header("Event Channel")]
    [SerializeField] private HomeSceneUIEventChannelSO homeSceneUIEventChannelSO;

    public void OnLoginButtonPressed()
    {
        homeSceneUIEventChannelSO.RaiseEvent(gameObject);
    }
}
