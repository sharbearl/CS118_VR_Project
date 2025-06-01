using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;


public class ThrowTreat : MonoBehaviour
{
    public GameObject treatPrefab;
    public Transform throwOrigin;
    public float throwForce = 10f;

    private InputDevice rightHandDevice;

    void Start()
    {
        // Get the right hand controller device
        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);
        if (rightHandDevices.Count > 0)
        {
            rightHandDevice = rightHandDevices[0];
        }
    }
    void Update()
{
    bool triggerPressed = false;

    // Check XR controller trigger
    if (rightHandDevice.isValid)
    {
        bool triggerValue;
        if (rightHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            triggerPressed = true;
        }
    }

    // Also check keyboard spacebar for testing
    if (Input.GetKeyDown(KeyCode.E))
    {
        triggerPressed = true;
    }

    if (triggerPressed)
    {
        Throw();
    }
}


    private bool hasThrown = false;

    void Throw()
    {
        if (hasThrown) return; // Prevent continuous throwing while holding the button

        GameObject treat = Instantiate(treatPrefab, throwOrigin.position, Quaternion.identity);
        Rigidbody rb = treat.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = throwOrigin.forward * throwForce;
        }
        hasThrown = true;

        // Optional: reset hasThrown after a short delay to allow next throw
        Invoke(nameof(ResetThrow), 0.3f);
    }

    void ResetThrow()
    {
        hasThrown = false;
    }
}
