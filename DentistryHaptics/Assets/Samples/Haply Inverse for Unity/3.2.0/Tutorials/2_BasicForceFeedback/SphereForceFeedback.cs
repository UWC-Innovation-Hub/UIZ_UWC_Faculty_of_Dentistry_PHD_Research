﻿/*
 * Copyright 2024 Haply Robotics Inc. All rights reserved.
 */

using Haply.Inverse.DeviceControllers;
using Haply.Inverse.DeviceData;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Haply.Samples.Tutorials._2_BasicForceFeedback
{
    public class SphereForceFeedback : MonoBehaviour
    {
        public Inverse3Controller inverse3Right;
        public Inverse3Controller inverse3Left;

        [Range(0, 800)]
        // Stiffness of the force feedback.
        public float stiffness = 300f;

        [Range(0, 3)]
        public float damping = 1f;

        private Vector3 _ballPosition;
        private float _ballRadius;
        private float _cursorRadiusRight;
        private float _cursorRadiusLeft;

        private Vector3 forceRight;
        private Vector3 forceLeft;

        [SerializeField]
        private Text _text;

        /// <summary>
        /// Stores the cursor and sphere transform data for access by the haptic thread.
        /// </summary>
        private void SaveSceneData()
        {
            var t = transform;
            _ballPosition = t.position;
            _ballRadius = t.lossyScale.x / 2f;

            _cursorRadiusRight = inverse3Right.Cursor.Radius;
            _cursorRadiusLeft = inverse3Left.Cursor.Radius;
        }

        /// <summary>
        /// Saves the initial scene data cache.
        /// </summary>
        private void Awake()
        {
            inverse3Right ??= FindFirstObjectByType<Inverse3Controller>();
            inverse3Left ??= FindFirstObjectByType<Inverse3Controller>();
            inverse3Right.Ready.AddListener((inverse3Right, args) => SaveSceneData());
            inverse3Left.Ready.AddListener((inverse3Left, args) => SaveSceneData());
        }

        /// <summary>
        /// Subscribes to the DeviceStateChanged event.
        /// </summary>
        private void OnEnable()
        {
            inverse3Right.DeviceStateChanged += OnDeviceStateChangedRight;
            inverse3Left.DeviceStateChanged += OnDeviceStateChangedLeft;    
        }

        /// <summary>
        /// Unsubscribes from the DeviceStateChanged event.
        /// </summary>
        private void OnDisable()
        {
            inverse3Right.DeviceStateChanged -= OnDeviceStateChangedRight;
            inverse3Right.Release();
            inverse3Left.DeviceStateChanged -= OnDeviceStateChangedLeft;    
            inverse3Left.Release();
        }

        /// <summary>
        /// Calculates the force based on the cursor's position and another sphere position.
        /// </summary>
        /// <param name="cursorPosition">The position of the cursor.</param>
        /// <param name="cursorVelocity">The velocity of the cursor.</param>
        /// <param name="cursorRadius">The radius of the cursor.</param>
        /// <param name="otherPosition">The position of the other sphere (e.g., ball).</param>
        /// <param name="otherRadius">The radius of the other sphere.</param>
        /// <returns>The calculated force vector.</returns>
        private Vector3 ForceCalculation(Vector3 cursorPosition, Vector3 cursorVelocity, float cursorRadius,
            Vector3 otherPosition, float otherRadius)
        {
            var force = Vector3.zero;

            var distanceVector = cursorPosition - otherPosition;
            var distance = distanceVector.magnitude;
            var penetration = otherRadius + cursorRadius - distance;

            if (penetration > 0)
            {
                // Normalize the distance vector to get the direction of the force
                var normal = distanceVector.normalized;

                // Calculate the force based on penetration
                force = normal * penetration * stiffness;

                // Apply damping based on the cursor velocity
                force -= cursorVelocity * damping;
            }

            return force;
        }

        /// <summary>
        /// Event handler that calculates and send the force to the device when the cursor's position changes.
        /// </summary>
        /// <param name="sender">The Inverse3 data object.</param>
        /// <param name="args">The event arguments containing the device data.</param>
        private void OnDeviceStateChangedRight(object sender, Inverse3EventArgs args)
        {
            var inverse3 = args.DeviceController;
            // Calculate the ball force
            forceRight = ForceCalculation(inverse3.CursorLocalPosition, inverse3.CursorLocalVelocity,
                _cursorRadiusRight, _ballPosition, _ballRadius);

            inverse3.SetCursorLocalForce(forceRight);

        }

        private void OnDeviceStateChangedLeft(object sender, Inverse3EventArgs args)
        {
            var inverse3 = args.DeviceController;
            // Calculate the ball force
            forceLeft = ForceCalculation(inverse3.CursorLocalPosition, inverse3.CursorLocalVelocity,
                _cursorRadiusLeft, _ballPosition, _ballRadius);

            inverse3.SetCursorLocalForce(forceLeft);

        }

        private void FixedUpdate()
        {
            _text.text = $"Force (N): {forceRight.magnitude:F2}";
            //Debug.Log($"Force (N): {force.magnitude:F2}");
        }
    }
}
