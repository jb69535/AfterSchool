using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHSScript : MonoBehaviour
{
    private GameObject VHS;
    public GameObject VHSInsertPosition;

    public AudioSource insertSFX;

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

        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag == "VHS") // VHS layer
        {
            Debug.Log("Trigger is working");
            VHS = other.transform.gameObject;
            VHS.transform.position = transform.position + new Vector3(-0.0f, 0f, 0f);

            VHS.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            VHS.transform.rotation = Quaternion.Euler(0f, 0f, -90f);

            //insertSFX.Play();

            StartCoroutine(MoveOverSeconds(VHS, VHSInsertPosition.transform.position, 3f));
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    
  public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds && objectToMove != null)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (objectToMove != null)
        {
            objectToMove.transform.position = end;
        }
    }

}
