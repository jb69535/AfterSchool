using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyController : MonoBehaviour
{
    public GameObject finalDoor;

    private void Start()
    {
        LockDoor();
    }

    private void LockDoor()
    {
        var doorRigidbody = finalDoor.GetComponent<Rigidbody>();
        doorRigidbody.constraints = RigidbodyConstraints.FreezeAll; // This locks the door in all axes, both position and rotation.
    }

    private void UnlockDoor()
    {
        var doorRigidbody = finalDoor.GetComponent<Rigidbody>();
        doorRigidbody.constraints = RigidbodyConstraints.None; // This unlocks the door so it can move freely.
        finalDoor.GetComponent<XRGrabInteractable>().enabled = true;
        // If you only want to allow rotation around Y axis (for example), you can set:
        // doorRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the key collides with a GameObject tagged "padlock"
        if (other.tag == "padlock")
        {
            // Destroy the padlock
            Destroy(other.gameObject);
            UnlockDoor();
        }
    }
}


