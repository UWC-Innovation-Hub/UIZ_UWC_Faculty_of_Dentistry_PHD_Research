using Leap;
using UnityEngine;

public class LeapCameraTest : MonoBehaviour
{
    [SerializeField] private LeapServiceProvider leapServiceProvider;

    private void Update()
    {
        if (leapServiceProvider == null)
            Debug.LogError($"Leap Service Provider (Desktop) is null, {leapServiceProvider}");


    }
}
