using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerJumpscare : MonoBehaviour
{

    public GameObject jumpscareCanvas;
    public GameObject jumpscareVideo;
    public GameObject respawnPoint;
    public GameObject jumpscarePoint;
    private GameObject player;

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
        if (other.gameObject.tag == "player")
        {
            Debug.Log("jumpscare");
            jumpscareCanvas.SetActive(true);
            jumpscareVideo.SetActive(true);
            other.gameObject.transform.position = jumpscarePoint.transform.position;
            other.gameObject.transform.rotation = jumpscarePoint.transform.rotation;
            player = other.gameObject;
            StartCoroutine(jumpScareTimer());
        }
    }

    private IEnumerator jumpScareTimer()
    {
        //while (true)
        //{
            yield return new WaitForSeconds(4.5f);
            jumpscareCanvas.SetActive(false);
            jumpscareVideo.SetActive(false);
            player.transform.position = respawnPoint.transform.position;
            player.transform.rotation = respawnPoint.transform.rotation;
        //}
    }

}
