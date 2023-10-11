using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balanceScript : MonoBehaviour
{
    public float thresholdMass = 15f;  // The mass at which the material should change.
    public Material newMaterial;       // The new material to apply.
    public GameObject objectToChange;  // The object whose material will be changed.
    private float currentMass = 0f;    // The current total mass on the plate.
    public GameObject key;  // The object whose material will be changed.
    public Transform keyposition;
    public Material tooHeavy;
    public Material oldMaterial;
    private bool trigger = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerStay(Collider other)
    {
        // Check if the collider has a Rigidbody (and thus, mass)
        if (other.attachedRigidbody)
        {
            // Add the mass of the entering object to the current mass.
            currentMass += other.attachedRigidbody.mass;
            CheckMassAndUpdateMaterial();
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    // Check if the collider has a Rigidbody (and thus, mass)
    //    if (other.attachedRigidbody)
    //    {
    //        // Subtract the mass of the exiting object from the current mass.
    //        currentMass -= other.attachedRigidbody.mass;
    //        CheckMassAndUpdateMaterial();
    //    }
    //}

    private void CheckMassAndUpdateMaterial()
    {
        // If the current mass exceeds the threshold, change the material.
        if (currentMass > thresholdMass - 10 && currentMass > thresholdMass + 10)
        {
            objectToChange.GetComponent<Renderer>().material = newMaterial;
            if (!trigger)
            {
                //Instantiate(key, keyposition.position, Quaternion.identity);
                key.transform.position = keyposition.transform.position;
                trigger = true;
            }


        }
        else if(currentMass > 100)
        {
            currentMass = 0;
            StartCoroutine(ChangeMaterialForSeconds(5f)); // 5 seconds.

        }
    }

    private IEnumerator ChangeMaterialForSeconds(float seconds)
    {
        GetComponent<Renderer>().material = tooHeavy; // Change to the new material.

        yield return new WaitForSeconds(seconds); // Wait for the specified duration.

        GetComponent<Renderer>().material = oldMaterial; // Revert to the original material.
    }
}
