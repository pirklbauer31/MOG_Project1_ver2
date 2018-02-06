using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre_Gold : MonoBehaviour, IHitable {

    public GameObject keyToSpawn;
    private Animator animator;
    private AudioSource[] trollSounds;
    private AudioSource deathSound;
    private AudioSource painSound;
    Subscription<MovementNotification> notificationToken;
    private Boolean enemyInSight;
    private AIMovement movement;
    public int Strength = 7;
    public int Defense = 10;
    public int health = 100;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            Console.WriteLine("Current Health: " + health);
            if (value <= 0)
                Die();
        }
    }
    // Use this for initialization
    void Start () {
        notificationToken=EventAggregator.SingletionAggregator.Subscribe<MovementNotification>(this.processPosition);
        animator = GetComponent<Animator>();
        // orgeSounds = GetComponents<AudioSource>();
        //deathSound = orgeSounds[0];
        movement = GetComponent<AIMovement>();
		trollSounds = GetComponents<AudioSource>();
        deathSound = trollSounds[0];
        painSound = trollSounds[1];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnGetHit(HitType type)
    {
        System.Random gen = new System.Random();
        int damage = 0;
        bool hasHit = false;
        int criticalBonus = 1;
        switch (type.Hit)
        {
            case HitType.FrontalHit:
                hasHit = gen.Next(100) <= 30 ? true : false;
                criticalBonus = gen.Next(100) <= 50 ? 1 : 2;
                damage = gen.Next(5, 14);
                break;
            case HitType.LeftSideHit:
                hasHit = gen.Next(100) <= 90 ? true : false;
                criticalBonus = gen.Next(100) <= 10 ? 1 : 2;
                damage = gen.Next(1, 12);
                break;
            case HitType.RightSideHit:
                hasHit = gen.Next(100) <= 10 ? true : false;
                criticalBonus = gen.Next(100) <= 80 ? 1 : 2;
                damage = gen.Next(5, 20);
                break;
            case HitType.TopDownHit:
                hasHit = true;
                damage = gen.Next(1, 8);
                break;
        }
        if (hasHit)
        {
            Health = Health - criticalBonus * damage * (type.Strength / Defense);
            animator.SetTrigger("damage");
            painSound.Play();
            hasHit = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IHitable>() != null)
        {
            other.gameObject.SendMessage("OnGetHit", new HitType(HitType.OrgeHit, Strength));
        }
    }
    public void processPosition(MovementNotification notification)
    {
        if (Math.Abs(notification.Position.x - transform.position.x) < movement.Sight && Math.Abs(notification.Position.z - transform.position.z) < movement.Sight)
        {
            print("Object in sight: " + notification.Group + "Distance x: " + Math.Abs(notification.Position.x - transform.position.x) + " z:" + Math.Abs(notification.Position.z - transform.position.z));
            enemyInSight = true;
            Attack();
        }
        else
            enemyInSight = false;
    }

    public void Idle()
    {
        animator.SetTrigger("idle");
        if (enemyInSight)
            Attack();
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
    }

    public void Die()
    {
        EventAggregator.SingletionAggregator.UnSbscribe(notificationToken);
        //GetComponent<CapsuleCollider>().enabled = false;
        //GetComponent<BoxCollider>().enabled = false;
        deathSound.Play();
        animator.SetTrigger("dead");
        //Destroy(gameObject);
        Console.WriteLine("Órge died");
        keyToSpawn.SetActive(true);
    }
	
    public void DeathAnimationFinished()
    {
        Destroy(gameObject);
    }
}
