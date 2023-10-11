using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Transform respawnPoint; // Assign this in the inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Press 'R' to respawn
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Set the player's position to the respawn point's position
        transform.position = respawnPoint.position;
    }
}
