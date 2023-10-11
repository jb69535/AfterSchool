using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateXZ : MonoBehaviour
{
    public float speed = 30f; // Speed of rotation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
