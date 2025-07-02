/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2024.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace Leap
{
    /// <summary>
    /// Aligns one source device with multiple target devices by transforming each target device
    /// until all bone positions align within the specified variance.
    /// </summary>
    public class MultideviceAlignment : MonoBehaviour
    {
        [Tooltip("The Leap provider to use as the reference/source.")]
        public LeapProvider sourceDevice;

        [Tooltip("List of Leap providers to align to the source device.")]
        public List<LeapProvider> targetDevices = new List<LeapProvider>();

        [Tooltip("Maximum allowed variance (in meters) between bone positions for alignment.")]
        public float alignmentVariance = 0.02f;

        private List<Vector3> sourceHandPoints = new List<Vector3>();
        private List<Vector3> targetHandPoints = new List<Vector3>();

        private KabschSolver solver = new KabschSolver();
        private Dictionary<LeapProvider, bool> alignmentCompleteMap = new Dictionary<LeapProvider, bool>();

        private void Start()
        {
            // Initialize alignment state for each target
            foreach (var target in targetDevices)
                alignmentCompleteMap[target] = false;
        }

        /// <summary>
        /// Forces re-alignment for all target devices.
        /// </summary>
        public void ReAlignAllProviders()
        {
            foreach (var target in targetDevices)
            {
                if (target != null)
                    target.transform.position = Vector3.zero;
                alignmentCompleteMap[target] = false;
            }
        }

        private void Update()
        {
            if (sourceDevice == null || sourceDevice.CurrentFrame == null)
                return;

            foreach (var target in targetDevices)
            {
                if (target == null || target.CurrentFrame == null)
                    continue;

                if (alignmentCompleteMap[target])
                    continue;

                sourceHandPoints.Clear();
                targetHandPoints.Clear();

                foreach (var sourceHand in sourceDevice.CurrentFrame.Hands)
                {
                    var targetHand = target.CurrentFrame.GetHand(
                        sourceHand.IsLeft ? Chirality.Left : Chirality.Right);
                    if (targetHand == null)
                        continue;

                    // Collect bone centers
                    for (int finger = 0; finger < 5; finger++)
                        for (int bone = 0; bone < 4; bone++)
                        {
                            sourceHandPoints.Add(sourceHand.fingers[finger].bones[bone].Center);
                            targetHandPoints.Add(targetHand.fingers[finger].bones[bone].Center);
                        }

                    // Check if aligned within variance
                    bool isAligned = true;
                    for (int i = 0; i < sourceHandPoints.Count; i++)
                    {
                        if (Vector3.Distance(sourceHandPoints[i], targetHandPoints[i]) > alignmentVariance)
                        {
                            isAligned = false;
                            break;
                        }
                    }

                    if (isAligned)
                    {
                        alignmentCompleteMap[target] = true;
                        break; // Move to next target
                    }

                    // Compute optimal transform via Kabsch
                    Matrix4x4 transformMatrix = solver.SolveKabsch(
                        targetHandPoints, sourceHandPoints, 200);
                    Matrix4x4 currentMatrix = target.transform.localToWorldMatrix;
                    Matrix4x4 newMatrix = transformMatrix * currentMatrix;

                    // Apply transformation
                    target.transform.position = newMatrix.GetVector3Kabsch();
                    target.transform.rotation = newMatrix.GetQuaternionKabsch();
                    target.transform.localScale = Vector3.Scale(
                        target.transform.localScale, transformMatrix.lossyScale);
                }
            }
        }
    }
}