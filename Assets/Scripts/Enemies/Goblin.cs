using System;
using UnityEngine;

public class Goblin : MonoBehaviour, IHitable
{
    private Animator animator;
    private AudioSource[] goblinSounds;
    private AudioSource deathSound;
    private AudioSource painSound;
    private AIMovement movement;
    private bool dead;
    private Boolean enemyInSight;
    Subscription<MovementNotification> notificationToken;
    public int Strength=5;
    public int Defense=7;
    public int health=100;

    public int Health { get { return health; }
        set {
            health = value;
            print("Current Health: "+health);
            if (value <= 0 &&! dead)
                Die();
        }
    }

    // Use this for initialization
    void Start()
    {
        notificationToken=EventAggregator.SingletionAggregator.Subscribe<MovementNotification>(this.processPosition);
        animator = GetComponent<Animator>();
        goblinSounds = GetComponents<AudioSource>();
        movement = GetComponent<AIMovement>();
        deathSound = goblinSounds[0];
        painSound = goblinSounds[1];
    }

    // Update is called once per frame
    void Update()
    {

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

    public void processPosition(MovementNotification notification) {
        if (Math.Abs(notification.Position.x - transform.position.x) < movement.Sight && Math.Abs(notification.Position.z - transform.position.z) < movement.Sight) { 
        print("Object in sight: " + notification.Group + "Distance x: " + Math.Abs(notification.Position.x - transform.position.x) + " z:" + Math.Abs(notification.Position.z - transform.position.z));
            enemyInSight = true;
            Attack();
    } else
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
        dead = true;
        EventAggregator.SingletionAggregator.UnSbscribe(notificationToken);
        //GetComponent<CapsuleCollider>().enabled = false;
        //GetComponent<BoxCollider>().enabled = false;
        deathSound.Play();
        animator.SetTrigger("dead");
        //Destroy(gameObject);
        print("Goblin died");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IHitable>() != null)
        {
            other.gameObject.SendMessage("OnGetHit", new HitType(HitType.GoblinHit,Strength));
        }
    }
        public void DeathAnimationFinished ()
    {
            Destroy(gameObject);
    }
}
