using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTreasure : MonoBehaviour
{
    public GameObject treasureCube;
    public AudioSource finalEffect;

    private void Start()
    {
        finalEffect = GetComponent<AudioSource>();

        if (finalEffect == null) {
            Debug.LogError("No AudioSource component found on this object.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == treasureCube && finalEffect != null) {
            finalEffect.Play();
        }
    }
}
