using UnityEngine;

public class AntiRollBar : MonoBehaviour
{
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
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ApplyAntiRollBar(wheelFrontL, wheelFrontR);
        ApplyAntiRollBar(wheelMiddleL, wheelMiddleR);
        ApplyAntiRollBar(wheelRearL, wheelRearR);
    }

    void ApplyAntiRollBar(WheelCollider wheelL, WheelCollider wheelR)
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = wheelL.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;

        bool groundedR = wheelR.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;

        float antiRollForce = (travelL - travelR) * antiRoll;

        if (groundedL)
            rb.AddForceAtPosition(wheelL.transform.up * -antiRollForce, wheelL.transform.position);
        if (groundedR)
            rb.AddForceAtPosition(wheelR.transform.up * antiRollForce, wheelR.transform.position);
    }
}
