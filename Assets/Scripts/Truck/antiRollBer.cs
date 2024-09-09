using UnityEngine;

public class AntiRollBar : MonoBehaviour
{
    // Each car should have its own set of WheelColliders
    public WheelCollider wheelFrontL;
    public WheelCollider wheelFrontR;
    public WheelCollider wheelMiddleL;
    public WheelCollider wheelMiddleR;
    public WheelCollider wheelRearL;
    public WheelCollider wheelRearR;
    public float antiRoll = 5000.0f;

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody attached to the car this script is attached to
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Apply the anti-roll logic separately for each wheel pair
        ApplyAntiRollBar(wheelFrontL, wheelFrontR);
        ApplyAntiRollBar(wheelMiddleL, wheelMiddleR);
        ApplyAntiRollBar(wheelRearL, wheelRearR);
    }

    void ApplyAntiRollBar(WheelCollider wheelL, WheelCollider wheelR)
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;

        // Check if the left wheel is grounded
        bool groundedL = wheelL.GetGroundHit(out hit);
        if (groundedL)
        {
            travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;
        }

        // Check if the right wheel is grounded
        bool groundedR = wheelR.GetGroundHit(out hit);
        if (groundedR)
        {
            travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;
        }

        // Calculate the anti-roll force based on the difference in suspension travel between the left and right wheels
        float antiRollForce = (travelL - travelR) * antiRoll;

        // Apply the anti-roll force to the Rigidbody (to prevent rolling)
        if (groundedL)
        {
            rb.AddForceAtPosition(wheelL.transform.up * -antiRollForce, wheelL.transform.position);
        }
        if (groundedR)
        {
            rb.AddForceAtPosition(wheelR.transform.up * antiRollForce, wheelR.transform.position);
        }
    }
}
