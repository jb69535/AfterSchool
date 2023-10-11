using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5.0f;
    public float rotationSpeed = 0.5f;
    private int currentWaypointIndex = 0;
    private bool isForward = true; // Variable to determine the direction of movement through waypoints

    void Update()
    {
        if (waypoints.Length == 0 || waypoints[currentWaypointIndex] == null)
            return;

        // Get the target position with the same y coordinate as the current position
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        targetPosition.y = transform.position.y;

        // Move towards the current waypoint's x and z, keeping y the same
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        // Orient towards the waypoint
        Vector3 directionToTarget = targetPosition - transform.position;
        if (directionToTarget.magnitude > 0.01f) // Avoid LookRotation for very small directions
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if we've reached the waypoint in the x and z dimensions
        if (transform.position.x == targetPosition.x && transform.position.z == targetPosition.z)
        {
            if (Random.value < 0.1f) // 50% chance to change direction
                isForward = !isForward; // Reverse the direction

            if (isForward)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Move to the next waypoint in the sequence
            }
            else
            {
                currentWaypointIndex--; // Move to the previous waypoint in the sequence
                if (currentWaypointIndex < 0)
                    currentWaypointIndex = waypoints.Length - 1; // Loop to the last waypoint if we were at the first one
            }
        }
    }
}
