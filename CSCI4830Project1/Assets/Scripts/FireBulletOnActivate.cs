using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    public float rotateAmount = 51.42857f; // there is 7 bullets for some reason
    private bool rotating = false;
    private bool rotatingH = false;
    private bool rotatingHB = false;
    private bool rotatingT = false;
    private bool rotatingTB = false;

    public GameObject trigger;
    public GameObject hammer;
    public GameObject cylinder;

    public ParticleSystem muzzleSmoke;
    public ParticleSystem flashEffect;

    public GameObject[] bullets;
    private bool reloading = false;
    public HapticInteractable haptic;

    public AudioSource shootSFX;
    public AudioSource reloadSFX;

    public TMP_Text bulletAmount;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);

        cylinder.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition; // makes sure the cylinder does not move while rotating
        cylinder.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        cylinder.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
    }

    // Update is called once per frame
    void Update()
    {
        if (bullets[bullets.Length - 1].activeInHierarchy == false && reloading == false)
        {
            reloading = true;
            haptic.enabled = false;
            reloadSFX.Play();
            bulletAmount.text = "Reloading";
            StartCoroutine(reloadingTimer());
        }
    }

    public void FireBullet(ActivateEventArgs arg)
    {

        if (reloading)
        {
            return;
        }
        shootSFX.time = 0.25f;
        shootSFX.Play();

        // Creating and shooting the bullet
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.transform.rotation = spawnPoint.rotation;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5); // destroys shooting bullet after 5 seconds

   

        // Removing bullet from cylinder
        for (int i = 0; i < bullets.Length; i++)
        {
            if (bullets[i].activeInHierarchy == true)
            {
                int currentBullet = 6 - i;
                bulletAmount.text = currentBullet.ToString();
                bullets[i].SetActive(false);
                break;
            }
        }

        // Rotating the cylinder
        //cylinder.transform.Rotate(0f, 0f, rotateAmount); // rotates cylinder to next bullet
        Quaternion rotation2 = Quaternion.Euler(new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, cylinder.transform.eulerAngles.z + rotateAmount)); // rising rotation
        StartCoroutine(rotateCylinder(cylinder, rotation2, 0.1f));

        // Hammer and Trigger Animation
        Quaternion rotationH = Quaternion.Euler(new Vector3(this.transform.eulerAngles.x - 20f, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
        StartCoroutine(rotateHammer(hammer, rotationH, 0.05f));

        Quaternion rotationHB = Quaternion.Euler(new Vector3(this.transform.eulerAngles.x + 0f, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
        StartCoroutine(rotateHammerBack(hammer, rotationHB, 0.05f));

        Quaternion rotationT = Quaternion.Euler(new Vector3(this.transform.eulerAngles.x + 30f, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
        StartCoroutine(rotateTrigger(trigger, rotationT, 0.05f));

        Quaternion rotationTB = Quaternion.Euler(new Vector3(this.transform.eulerAngles.x + 0f, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
        StartCoroutine(rotateTriggerBack(trigger, rotationTB, 0.05f));



        // Smoke Effects
        muzzleSmoke.Play();
        flashEffect.Play();


    }

    IEnumerator reloadingTimer()
    {
        yield return new WaitForSeconds(3.0f);
        //Debug.Log("Reloaded");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].SetActive(true);
        }
        reloading = false;
        haptic.enabled = true;
        bulletAmount.text = "7";
    }

    IEnumerator rotateCylinder(GameObject gameObjectToMove, Quaternion newRot, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;

        Quaternion currentRot = gameObjectToMove.transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
    }

    IEnumerator rotateHammer(GameObject gameObjectToMove, Quaternion newRot, float duration)
    {
        if (rotatingH)
        {
            yield break;
        }
        rotatingH = true;

        Quaternion currentRot = gameObjectToMove.transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotatingH = false;
    }

    IEnumerator rotateHammerBack(GameObject gameObjectToMove, Quaternion newRot, float duration)
    {

        yield return new WaitForSeconds(0.05f);

        if (rotatingHB)
        {
            yield break;
        }
        rotatingHB = true;

        Quaternion currentRot = gameObjectToMove.transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotatingHB = false;
    }

    IEnumerator rotateTrigger(GameObject gameObjectToMove, Quaternion newRot, float duration)
    {
        if (rotatingT)
        {
            yield break;
        }
        rotatingT = true;

        Quaternion currentRot = gameObjectToMove.transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotatingT = false;
    }

    IEnumerator rotateTriggerBack(GameObject gameObjectToMove, Quaternion newRot, float duration)
    {
        yield return new WaitForSeconds(0.05f);

        if (rotatingTB)
        {
            yield break;
        }
        rotatingTB = true;

        Quaternion currentRot = gameObjectToMove.transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotatingTB = false;
    }


}