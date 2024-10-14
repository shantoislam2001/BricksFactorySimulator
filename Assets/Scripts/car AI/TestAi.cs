using UnityEngine;

public class CarAITest : MonoBehaviour
{
    [System.Serializable]
    public class Waypoint
    {
        public Transform waypointTransform;
        public float speedLimit = 150f;
        public bool applyBrakes = false;
        public float brakeTorque = 300f;
    }

    [System.Serializable]
    public class WaypointList
    {
        public string listName;
        public Waypoint[] waypoints;
    }

    [System.Serializable]
    public class CarWaypointMapping
    {
        public string carName;
        public WaypointList[] waypointLists;
    }

    public CarWaypointMapping[] carWaypointMappings;
    public float maxSteerAngle = 30f;
    public float defaultMotorTorque = 150f;
    public float waypointRadius = 5f;
    public float reverseSpeed = -50f;
    public float reverseDelay = 2f;

    public WheelCollider frontLeftWheel, frontRightWheel, middleLeftWheel, middleRightWheel, rearLeftWheel, rearRightWheel;
    public Transform frontLeftTransform, frontRightTransform, middleLeftTransform, middleRightTransform, rearLeftTransform, rearRightTransform;

    public float sensorLength = 5f;
    public float sensorAngle = 30f;
    public LayerMask obstacleLayer;

    private Waypoint[] activeWaypoints;
    private int currentWaypointIndex = 0;
    private bool isStopped = false;
    private bool isReversing = false;
    private float reverseTimer = 0f;

    void Update()
    {
        if (activeWaypoints == null || activeWaypoints.Length == 0 || isStopped) return;

        if (!DetectObstacle())
        {
            ApplySteering();
            ApplyMotorTorque();
        }

        UpdateWheelPoses();

        float distanceToWaypoint = Vector3.Distance(transform.position, activeWaypoints[currentWaypointIndex].waypointTransform.position);

        if (distanceToWaypoint < waypointRadius)
        {
            if (currentWaypointIndex == activeWaypoints.Length - 1)
            {
                StopCar();
            }
            else
            {
                currentWaypointIndex++;
            }
        }
        else if (distanceToWaypoint > waypointRadius && IsWaypointBehind())
        {
            StartReversing();
        }
        else if (isReversing && reverseTimer > reverseDelay)
        {
            StopReversing();
        }
    }

    bool DetectObstacle()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position + transform.forward * 2f;

        bool obstacleDetected = false;

        // Forward Sensor
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength, obstacleLayer))
        {
            obstacleDetected = true;
        }

        // Right angled sensor
        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(sensorAngle, transform.up) * transform.forward, out hit, sensorLength, obstacleLayer))
        {
            obstacleDetected = true;
        }

        // Left angled sensor
        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-sensorAngle, transform.up) * transform.forward, out hit, sensorLength, obstacleLayer))
        {
            obstacleDetected = true;
        }

        if (obstacleDetected)
        {
            ApplyBrakes(500f);
            return true;
        }

        return false;
    }

    void ApplySteering()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(activeWaypoints[currentWaypointIndex].waypointTransform.position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

        frontLeftWheel.steerAngle = newSteer;
        frontRightWheel.steerAngle = newSteer;
    }

    void ApplyMotorTorque()
    {
        if (isReversing)
        {
            rearLeftWheel.motorTorque = reverseSpeed;
            rearRightWheel.motorTorque = reverseSpeed;
            middleLeftWheel.motorTorque = reverseSpeed;
            middleRightWheel.motorTorque = reverseSpeed;
        }
        else
        {
            float motorTorque = defaultMotorTorque;
            if (activeWaypoints.Length > 0)
            {
                float speedLimit = activeWaypoints[currentWaypointIndex].speedLimit;
                motorTorque = Mathf.Clamp(motorTorque, 0, speedLimit);
            }

            rearLeftWheel.motorTorque = motorTorque;
            rearRightWheel.motorTorque = motorTorque;
            middleLeftWheel.motorTorque = motorTorque;
            middleRightWheel.motorTorque = motorTorque;

            if (activeWaypoints.Length > 0 && activeWaypoints[currentWaypointIndex].applyBrakes)
            {
                ApplyBrakes(activeWaypoints[currentWaypointIndex].brakeTorque);
            }
        }
    }

    void ApplyBrakes(float brakeTorque)
    {
        rearLeftWheel.brakeTorque = brakeTorque;
        rearRightWheel.brakeTorque = brakeTorque;
        middleLeftWheel.brakeTorque = brakeTorque;
        middleRightWheel.brakeTorque = brakeTorque;
        frontLeftWheel.brakeTorque = brakeTorque;
        frontRightWheel.brakeTorque = brakeTorque;
    }

    void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftWheel, frontLeftTransform);
        UpdateWheelPose(frontRightWheel, frontRightTransform);
        UpdateWheelPose(middleLeftWheel, middleLeftTransform);
        UpdateWheelPose(middleRightWheel, middleRightTransform);
        UpdateWheelPose(rearLeftWheel, rearLeftTransform);
        UpdateWheelPose(rearRightWheel, rearRightTransform);
    }

    void UpdateWheelPose(WheelCollider collider, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        trans.position = position;
        trans.rotation = rotation;
    }

    void StopCar()
    {
        rearLeftWheel.motorTorque = 0f;
        rearRightWheel.motorTorque = 0f;
        middleLeftWheel.motorTorque = 0f;
        middleRightWheel.motorTorque = 0f;
        ApplyBrakes(300f);
        isStopped = true;
    }

    bool IsWaypointBehind()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(activeWaypoints[currentWaypointIndex].waypointTransform.position);
        return relativeVector.z < 0;
    }

    void StartReversing()
    {
        if (!isReversing)
        {
            isReversing = true;
            reverseTimer = 0f;
            rearLeftWheel.brakeTorque = 0f;
            rearRightWheel.brakeTorque = 0f;
            middleLeftWheel.brakeTorque = 0f;
            middleRightWheel.brakeTorque = 0f;
        }
        reverseTimer += Time.deltaTime;
    }

    void StopReversing()
    {
        isReversing = false;
        reverseTimer = 0f;
    }

    public void SetActiveWaypointList(string carName, string waypointListName)
    {
        foreach (CarWaypointMapping carMapping in carWaypointMappings)
        {
            if (carMapping.carName == carName)
            {
                foreach (WaypointList list in carMapping.waypointLists)
                {
                    if (list.listName == waypointListName)
                    {
                        activeWaypoints = list.waypoints;
                        currentWaypointIndex = 0;
                        isStopped = false;
                        StopReversing(); // Stop reversing if the car was in reverse
                        ApplyBrakes(0f); // Release the brakes
                        return;
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (activeWaypoints != null && activeWaypoints.Length > 0)
        {
            for (int i = 0; i < activeWaypoints.Length; i++)
            {
                if (i < activeWaypoints.Length - 1)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(activeWaypoints[i].waypointTransform.position, activeWaypoints[i + 1].waypointTransform.position);
                }
            }
        }
    }
}
