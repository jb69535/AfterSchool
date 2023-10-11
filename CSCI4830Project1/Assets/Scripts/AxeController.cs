using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    int breakingPoint = 3;
    int plankBreakingPoint = 2;
    int boxCounter = 0;
    int plankCounter = 0;
    public GameObject brokenObject;
    public GameObject crackBox1;
    public GameObject crackBox2;
    public AudioSource woodSound;
    public GameObject plankDoor;
    public GameObject VHS;

    private void Start()
    {
        LockDoor();
    }

    private void LockDoor()
    {
        var doorRigidbody = plankDoor.GetComponent<Rigidbody>();
        doorRigidbody.constraints = RigidbodyConstraints.FreezeAll; // This locks the door in all axes, both position and rotation.
    }

    private void UnlockDoor()
    {
        var doorRigidbody = plankDoor.GetComponent<Rigidbody>();
        doorRigidbody.constraints = RigidbodyConstraints.None; // This unlocks the door so it can move freely.
        // If you only want to allow rotation around Y axis (for example), you can set:
        // doorRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 boxPosition = other.transform.position;
        if (other.tag == "plank")
        {
            plankCounter++;
            woodSound.Play();
            Destroy(other.gameObject);
            if (plankCounter >= plankBreakingPoint) {
                UnlockDoor();
            }
        }
        if (other.tag == "box")
        {
            woodSound.Play();
            boxCounter++;
            if (boxCounter == 1)
            {
                Destroy(other.gameObject); // Destroy original box
                Instantiate(crackBox1, boxPosition, Quaternion.identity); // First hit feedback
            }
            else if (boxCounter == 2)
            {
                Debug.Log("box renew");
                Destroy(other.gameObject);
                Instantiate(crackBox2, boxPosition, Quaternion.identity); // Second hit feedback
            }
            else if (boxCounter >= breakingPoint)
            {
                Debug.Log("brokenBox came out");
                Destroy(other.gameObject);
                Instantiate(brokenObject, boxPosition, Quaternion.identity); // Box breaks
                VHS.transform.position = boxPosition + new Vector3 (0.1f, 0, 0);
            }
        }
    }
}


