using VelUtils;
using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeMovement : MonoBehaviour
{
    public GameObject leftController;
    public GameObject rightController;
    public Vector3 targetPosition;
    public float moveSpeed = 3.0f;  // Speed to move towards the target
    public float maxRayDistance = 150.0f;  // Maximum distance to set the targetPosition if ray doesn't hit anything
    public bool moveStop;

    void Update()
    {
        if (Input.GetButton("VR_Button1_Left"))
        {   
            RaycastHit hit;
            if (Physics.Raycast(leftController.transform.position, leftController.transform.forward, out hit))
            {
                targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
            else
            {
                Vector3 directionPoint = leftController.transform.position + leftController.transform.forward * maxRayDistance;
                targetPosition = new Vector3(directionPoint.x, transform.position.y, directionPoint.z);
            }
            moveStop = true;
        }

        if (Input.GetButtonUp("VR_Button1_Left"))
        {
            Debug.Log("Stop moving");
            moveStop = false;
        }

        if (Input.GetButton("VR_Button1_Right"))
        {
            RaycastHit hit;
            if (Physics.Raycast(rightController.transform.position, rightController.transform.forward, out hit))
            {
                targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
            else
            {
                Vector3 directionPoint = rightController.transform.position + rightController.transform.forward * maxRayDistance;
                targetPosition = new Vector3(directionPoint.x, transform.position.y, directionPoint.z);
            }
            moveStop = true;
        }

        if (Input.GetButtonUp("VR_Button1_Right"))
        {
            Debug.Log("Stop moving");
            moveStop = false;
        }

    }

    void FixedUpdate()
    {
        // Move towards the target position in FixedUpdate
        if (moveStop && (targetPosition != Vector3.zero))
        {
            Vector3 directionToTarget = (targetPosition - transform.position).normalized;
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToTarget, out hit, distanceToTarget))
            {
                // If there's an obstacle in the way, set the targetPosition to be just in front of the obstacle
                targetPosition = hit.point - directionToTarget * 0.1f; // Adjust by a small offset to ensure we don't overlap with the obstacle
            }

            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            transform.position = newPosition;
        }
    }
}
