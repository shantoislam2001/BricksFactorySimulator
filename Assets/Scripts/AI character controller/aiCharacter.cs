using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiCharacter : MonoBehaviour
{
    public List<Transform> currentWaypoints; // List of waypoints the character will follow
    public float moveSpeed = 2f;             // Movement speed of the AI character
    public float waypointTolerance = 0.2f;   // How close the character needs to get to a waypoint to consider it reached

    private int currentWaypointIndex = 0;
    private bool isMoving = true;
    private bool hasReachedLastWaypoint = false;
    [SerializeField] public Animator animator;

    void Start()
    {
        if (currentWaypoints == null || currentWaypoints.Count == 0)
        {
            Debug.LogError("No waypoints assigned!");
            isMoving = false;
        }
    }

    void Update()
    {
        if (isMoving && currentWaypoints.Count > 0)
        {
            MoveTowardsWaypoint();
        }
    }

    void MoveTowardsWaypoint()
    {
        if (hasReachedLastWaypoint)
            return;

        Transform targetWaypoint = currentWaypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        direction.y = 0; // Ensure the AI stays grounded

        // Move the character towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // Face the target waypoint
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
        }

        // Check if the AI has reached the waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < waypointTolerance)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= currentWaypoints.Count)
            {
                // If the last waypoint is reached, stop moving
                hasReachedLastWaypoint = true;
                StopMoving();
            }
        }
    }

    // Method to stop the AI character
    public void StopMoving()
    {
        isMoving = false;
        animator.SetBool("walk", false);
    }

    // Method to start moving the AI character
    public void StartMoving()
    {
        if (currentWaypoints.Count > 0)
        {
            isMoving = true;
            hasReachedLastWaypoint = false;
        }
    }

    // Method to switch to a new list of waypoints and reset movement
    public void SwitchWaypoints(List<Transform> newWaypoints)
    {
        currentWaypoints = newWaypoints;
        currentWaypointIndex = 0;
        hasReachedLastWaypoint = false;
        StartMoving();
    }
}
