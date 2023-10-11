using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class menuRespawn : MonoBehaviour
{

    public GameObject respawnPoint;
    public GameObject respawnHome;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respawnToPoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       // player.transform.position = respawnPoint.transform.position;
       // player.transform.rotation = respawnPoint.transform.rotation;
        

    }

    public void respawnToHome()
    {
        player.transform.position = respawnPoint.transform.position;
        player.transform.rotation = respawnPoint.transform.rotation;
    }

}
