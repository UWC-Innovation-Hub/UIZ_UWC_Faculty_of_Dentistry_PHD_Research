using Haply.Inverse.Unity;
using UnityEngine;

public class VerseGripPositionControl : MonoBehaviour
{
    public Inverse3 inverse3;      // assign in inspector
    public VerseGrip verseGrip;    // assign in inspector
    [Range(0f, 1f)] public float speed = 0.5f;
    [Range(0f, 0.2f)] public float movementLimitRadius = 0.2f;

    private Vector3 _targetPosition;

    private void OnEnable() => verseGrip.DeviceStateChanged += OnDeviceStateChanged;
    private void OnDisable() => verseGrip.DeviceStateChanged -= OnDeviceStateChanged;

    private void OnDeviceStateChanged(VerseGrip grip)
    {
        var direction = grip.LocalRotation * Vector3.forward;

        if (grip.GetButtonDown())
            _targetPosition = inverse3.LocalPosition;

        if (grip.GetButton())
        {
            _targetPosition += direction * (0.0025f * speed);
            var center = inverse3.WorkspaceCenter;
            _targetPosition = Vector3.ClampMagnitude(_targetPosition - center, movementLimitRadius) + center;
            inverse3.CursorSetLocalPosition(_targetPosition);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            inverse3.TryResetForce();
    }
}
