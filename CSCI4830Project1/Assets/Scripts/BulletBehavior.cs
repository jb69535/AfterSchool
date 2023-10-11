using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    int MonsterHP = 1;
    int MonsterDead = 0;
    public AudioSource hitSFX;
    public AudioSource deathSFX;
    public monsterHealth health;
    public GameObject treasureCube;
    private void OnTriggerEnter(Collider other)
    {
        Vector3 monsterPosition = other.transform.position;
        if (other.gameObject.tag == "Monster")
        {
            MonsterHP--;
            hitSFX.Play();
            Debug.Log("hit monster");

            if (MonsterHP <= MonsterDead)
            {
                Destroy(other.gameObject);
                deathSFX.Play();
                Instantiate(treasureCube, monsterPosition, Quaternion.identity);
            }
        }

    }
}
