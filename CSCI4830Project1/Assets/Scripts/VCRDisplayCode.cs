using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VCRDisplayCode : MonoBehaviour
{

    public GameObject VCR_Screen;
    public Sprite codeSprite;
    public AudioSource creepyAudio1;
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
        if (other.tag == "VHS")
        {
            Destroy(other.gameObject);
            VCR_Screen.GetComponent<Image>().sprite = codeSprite;
            creepyAudio1.Play();
        }
    }

}
