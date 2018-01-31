using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre_Gold : MonoBehaviour, IEnemyHitable {

    public GameObject keyToSpawn;

    private Animator animator;
    private AudioSource[] trollSounds;
    private AudioSource deathSound;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        trollSounds = GetComponents<AudioSource>();
        deathSound = trollSounds[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnGetHit (HitType t)
    {
        Die();
    }

    public void Die()
    {
        deathSound.Play();
        animator.SetTrigger("dead");
        //Destroy(gameObject);
        keyToSpawn.SetActive(true);
    }

    public void DeathAnimationFinished(int state)
    {
        if (state == 1)
        {
            Destroy(gameObject);
        }
    }
}
