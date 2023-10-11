using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed

    void Update()
    {
        Vector3 movement = Vector3.zero; // Initialize movement vector

        // Check for arrow key inputs and update movement vector accordingly
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector3.right;
        }

        // Normalize movement vector to ensure consistent movement speed in all directions
        movement.Normalize();

        // Apply movement to camera position
        transform.position += movement * speed * Time.deltaTime;
    }
}
