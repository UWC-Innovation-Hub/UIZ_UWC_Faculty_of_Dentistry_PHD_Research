---
name: XR Regression Test Case
about: Use this template for creating regression test cases for XR experiences
title: "[XR REGRESSION TEST] - Testing existing XR functionality after changes"
labels: Testing, Regression Testing, XR Testing
assignees: KaylynFritz, AyeshaBoomgaard

---

## Changes Being Verified
Specify what changes or updates were made that necessitate regression testing (e.g., engine update, SDK update, new feature addition).

## Regression Test Objective
Describe what aspects of the existing XR system you're verifying hasn't been negatively impacted.

## Test Environment
- XR Platform(s): [e.g., Oculus Quest 2, HoloLens 2, WebXR]
- Framework/Engine Version: [Current version number]
- Previous Version: [Version before changes]
- SDK Versions: [List relevant SDKs and versions]
- Test Device Specifications: [e.g., CPU, GPU, RAM]

## Areas Potentially Affected
- [e.g., Hand tracking accuracy]
- [e.g., Rendering performance]
- [e.g., Spatial mapping]
- [e.g., UI interactions]

## XR Regression Test Suite

### Test Case 1: [Brief description of test case]
**XR Feature**: [e.g., Object grabbing, Teleportation, UI interaction]

**Preconditions**: 
- [e.g., User is in tracked space]
- [e.g., Controllers are paired]

**Test Steps**:
1. [Step 1]
2. [Step 2]
3. [Step 3]

**Expected Results**:
- [e.g., Object should attach to hand]
- [e.g., User should teleport to target location]
- [e.g., UI element should respond to selection]

**Worked Previously**: [Yes/No]
**Works Now**: [Yes/No/To Be Verified]
**Performance Impact**: [None/Minor/Major/To Be Measured]

### Test Case 2: [Brief description of test case]
**XR Feature**: [e.g., Object grabbing, Teleportation, UI interaction]

**Preconditions**: 
- [e.g., User is in tracked space]
- [e.g., Controllers are paired]

**Test Steps**:
1. [Step 1]
2. [Step 2]
3. [Step 3]

**Expected Results**:
- [e.g., Object should attach to hand]
- [e.g., User should teleport to target location]
- [e.g., UI element should respond to selection]

**Worked Previously**: [Yes/No]
**Works Now**: [Yes/No/To Be Verified]
**Performance Impact**: [None/Minor/Major/To Be Measured]

## Critical XR Performance Metrics
- Frame rate (Previously: [e.g., 90FPS], Current: [To be measured])
- Motion-to-photon latency (Previously: [e.g., 20ms], Current: [To be measured])
- Tracking accuracy (Previously: [e.g., 1mm], Current: [To be measured])
- Battery consumption rate (Previously: [e.g., 10%/hour], Current: [To be measured])

## XR-Specific Regression Concerns
- [e.g., Tracking quality under different lighting conditions]
- [e.g., Hand occlusion handling]
- [e.g., Physics interactions stability]
- [e.g., Multi-user synchronization]

## Platform-Specific Tests
List any tests that need to be run specifically for certain platforms or devices.

## Automated Tests
- [ ] Automated regression test suite exists
- [ ] Automation needs updating after changes
- [ ] Performance capture automation
- [ ] Manual testing only

## Additional Notes
Any other relevant information for XR regression testing.
