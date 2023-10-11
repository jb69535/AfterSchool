using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOutline : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hands")
        {
            this.gameObject.GetComponent<Outline>().enabled = true; // outlines object when hands are touching it
        }
        //Debug.Log("Touching hands");
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "hands")
        {
            this.gameObject.GetComponent<Outline>().enabled = false; // disables outline of object when hands are not touching
        }
        //Debug.Log("Exiting hands");

    }

}
