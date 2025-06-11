using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Home Scene UI Event Channel SO")]
public class HomeSceneUIEventChannelSO : ScriptableObject
{
    public event Action<GameObject> OnLoginEventRaised;

    public void RaiseEvent(GameObject loginUIGameObject)
    {
        OnLoginEventRaised?.Invoke(loginUIGameObject);
    }
}
