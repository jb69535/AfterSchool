using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils;

public class handMenu : MonoBehaviour
{

    bool pressed = false;
    bool closed = true;
    public Animator menuAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("VR_Trigger_Left") > 0 && closed == true)
        {
            pressed = true;
            Debug.Log("Button is pressed");
            menuAnimator.SetTrigger("Open");
            //if (Input.GetAxis("VR_Trigger_Left") > 0)
            // {
            //    menuAnimator.Play("OpenedGameMenu");
            //}
            closed = false;

        } else if (Input.GetAxis("VR_Trigger_Left") == 0 && closed == false)
        {
            //menuAnimator.SetTrigger("Close");
            //menuAnimator.Play("ClosingGameMenu");
            menuAnimator.SetTrigger("Close");
            pressed = false;
            closed = true;

        }

    }
}
