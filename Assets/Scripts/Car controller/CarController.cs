using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CarController : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider middleLeftWheel;
    public WheelCollider middleRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    [Header("Wheel Transforms")]
    public Transform frontLeftTransform;
    public Transform frontRightTransform;
    public Transform middleLeftTransform;
    public Transform middleRightTransform;
    public Transform rearLeftTransform;
    public Transform rearRightTransform;

    [Header("Car Settings")]
    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 30f;
    public float brakeForce = 3000f;

    [Header("Gear Settings")]
    public int numberOfGears = 5;
    public float[] gearRatios;

    [Header("UI Buttons")]
    public Button accelerateButton;
    public Button brakeButton;
    public Button steerLeftButton;
    public Button steerRightButton;
    public Button reverseButton;

    private float motorInput = 0f;
    private float steerInput = 0f;
    private bool isBraking = false;
    private int currentGear = 1;
    private float currentSpeed;

    private void Start()
    {
        // Initialize button listeners
        AddButtonListeners();
    }

    private void AddButtonListeners()
    {
        AddEventTriggerListener(accelerateButton.gameObject, EventTriggerType.PointerDown, OnAccelerateDown);
        AddEventTriggerListener(accelerateButton.gameObject, EventTriggerType.PointerUp, OnAccelerateUp);
        AddEventTriggerListener(reverseButton.gameObject, EventTriggerType.PointerDown, OnReverseDown);
        AddEventTriggerListener(reverseButton.gameObject, EventTriggerType.PointerUp, OnReverseUp);
        AddEventTriggerListener(brakeButton.gameObject, EventTriggerType.PointerDown, OnBrakeDown);
        AddEventTriggerListener(brakeButton.gameObject, EventTriggerType.PointerUp, OnBrakeUp);
        AddEventTriggerListener(steerLeftButton.gameObject, EventTriggerType.PointerDown, OnSteerLeftDown);
        AddEventTriggerListener(steerLeftButton.gameObject, EventTriggerType.PointerUp, OnSteerLeftUp);
        AddEventTriggerListener(steerRightButton.gameObject, EventTriggerType.PointerDown, OnSteerRightDown);
        AddEventTriggerListener(steerRightButton.gameObject, EventTriggerType.PointerUp, OnSteerRightUp);
    }

    private void AddEventTriggerListener(GameObject target, EventTriggerType eventType, UnityEngine.Events.UnityAction action)
    {
        EventTrigger trigger = target.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = target.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener((data) => action());

        trigger.triggers.Add(entry);
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheelTransforms();
    }

    private void HandleMotor()
    {
        float motor = motorInput * maxMotorTorque;
        float brake = isBraking ? brakeForce : 0f;

        frontLeftWheel.motorTorque = motor;
        frontRightWheel.motorTorque = motor;
        middleLeftWheel.motorTorque = motor;
        middleRightWheel.motorTorque = motor;
        rearLeftWheel.motorTorque = motor;
        rearRightWheel.motorTorque = motor;

        if (isBraking)
        {
            ApplyBraking(brake);
        }
        else
        {
            frontLeftWheel.brakeTorque = 0f;
            frontRightWheel.brakeTorque = 0f;
            middleLeftWheel.brakeTorque = 0f;
            middleRightWheel.brakeTorque = 0f;
            rearLeftWheel.brakeTorque = 0f;
            rearRightWheel.brakeTorque = 0f;
        }

        currentSpeed = GetComponent<Rigidbody>().linearVelocity.magnitude * 3.6f;
        UpdateGear();
    }

    private void ApplyBraking(float brakeForce)
    {
        frontLeftWheel.brakeTorque = brakeForce;
        frontRightWheel.brakeTorque = brakeForce;
        middleLeftWheel.brakeTorque = brakeForce;
        middleRightWheel.brakeTorque = brakeForce;
        rearLeftWheel.brakeTorque = brakeForce;
        rearRightWheel.brakeTorque = brakeForce;
    }

    private void HandleSteering()
    {
        float steering = steerInput * maxSteeringAngle;
        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;
    }

    private void UpdateWheelTransforms()
    {
        UpdateWheelTransform(frontLeftWheel, frontLeftTransform);
        UpdateWheelTransform(frontRightWheel, frontRightTransform);
        UpdateWheelTransform(middleLeftWheel, middleLeftTransform);
        UpdateWheelTransform(middleRightWheel, middleRightTransform);
        UpdateWheelTransform(rearLeftWheel, rearLeftTransform);
        UpdateWheelTransform(rearRightWheel, rearRightTransform);
    }

    private void UpdateWheelTransform(WheelCollider wheelCollider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        transform.position = position;
        transform.rotation = rotation;
    }

    private void UpdateGear()
    {
        float gearFactor = currentSpeed / (maxMotorTorque / numberOfGears);
        int newGear = Mathf.Clamp(Mathf.FloorToInt(gearFactor) + 1, 1, numberOfGears);

        if (newGear != currentGear)
        {
            currentGear = newGear;
        }
    }

    // Input methods for button events
    private void OnAccelerateDown()
    {
        motorInput = 1f;
    }

    private void OnAccelerateUp()
    {
        motorInput = 0f;
    }

    private void OnReverseDown()
    {
        motorInput = -1f;
    }

    private void OnReverseUp()
    {
        motorInput = 0f;
    }

    private void OnBrakeDown()
    {
        isBraking = true;
    }

    private void OnBrakeUp()
    {
        isBraking = false;
    }

    private void OnSteerLeftDown()
    {
        steerInput = -1f;
    }

    private void OnSteerLeftUp()
    {
        steerInput = 0f;
    }

    private void OnSteerRightDown()
    {
        steerInput = 1f;
    }

    private void OnSteerRightUp()
    {
        steerInput = 0f;
    }
}
