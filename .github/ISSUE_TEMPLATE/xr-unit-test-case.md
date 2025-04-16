---
name: XR Unit Test Case
about: Use this template for creating unit test cases for XR components
title: "[XR UNIT TEST] - Testing individual XR component or function"
labels: Testing, Unit Testing, XR Testing
assignees: KaylynFritz, AyeshaBoomgaard

---

## XR Component Being Tested
Specify the exact component being tested (e.g., Object Interaction Controller, VR Locomotion System).

## Test Objective
Describe what specific functionality of the component you're testing.

## Test Environment
- XR Platform: [e.g., Oculus Quest 2, HoloLens 2, WebXR]
- Framework/Engine: [e.g., Unity, Unreal, Three.js]
- SDK Version: [e.g., Unity XR Plugin 4.2.1]
- Test Device Specifications: [e.g., CPU, GPU, RAM]

## Unit Test Cases

### Test Case 1: [Brief description]
**Input/Action**: 
- Controller input: [e.g., Trigger press, Grip button]
- Parameter values: [e.g., Transform position (0,1,0)]
- Initial state: [e.g., Object is grabbable]

**Expected Output/Behavior**: 
- [e.g., Object should attach to hand transform]
- [e.g., Haptic feedback should trigger]
- [e.g., Visual indicator should appear]

**Verification Method**:
- [ ] Visual inspection
- [ ] Log output verification
- [ ] Unit test assertion
- [ ] Performance metric

### Test Case 2: [Brief description]
**Input/Action**: 
- Controller input: [e.g., Trigger press, Grip button]
- Parameter values: [e.g., Transform position (0,1,0)]
- Initial state: [e.g., Object is grabbable]

**Expected Output/Behavior**: 
- [e.g., Object should attach to hand transform]
- [e.g., Haptic feedback should trigger]
- [e.g., Visual indicator should appear]

**Verification Method**:
- [ ] Visual inspection
- [ ] Log output verification
- [ ] Unit test assertion
- [ ] Performance metric

## Edge Cases to Test
- [e.g., Rapid input sequence]
- [e.g., Extreme distance values]
- [e.g., Multiple simultaneous interactions]
- [e.g., Testing during frame drops]

## Performance Considerations
- Target frame rate: [e.g., 90 FPS]
- Max acceptable latency: [e.g., 20ms]
- Memory allocation limits: [e.g., 10MB]

## Dependencies
List any dependencies or prerequisites required for these tests.

## Related Components
List related components that this component interacts with.

## Additional Notes
Any other relevant information for the tester.
