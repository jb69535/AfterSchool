using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openMap : MonoBehaviour
{

    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("VR_Button2_Left"))
        {
            map.SetActive(true);
        }  else if (Input.GetButtonUp("VR_Button2_Left"))
        {
            map.SetActive(false);
        }
    }



}
