using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class inputCodeValue : MonoBehaviour

{
    // Start is called before the first frame update

    public int buttonValue;
    public TMP_Text codeText;
    public int correctCode = 1234;
    public XRGrabInteractable safeHandle;
    public AudioSource doorKnock;
    public AudioSource buttonPressSFX;
    public AudioSource wrongSFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCode()
    {
        codeText.text = codeText.text + buttonValue.ToString();
        buttonPressSFX.Play();
    }

    public void cancelCode()
    {
        codeText.text = "";
        buttonPressSFX.Play();
    }

    public void sumbitCode()
    {
        
        if (codeText.text == correctCode.ToString())
        {
            Debug.Log("Correct Code!");
            safeHandle.enabled = true;
            codeText.text = "Correct";
            doorKnock.Play();
        } else
        {
            codeText.text = "";
            wrongSFX.Play();
        }
        
    }
}
