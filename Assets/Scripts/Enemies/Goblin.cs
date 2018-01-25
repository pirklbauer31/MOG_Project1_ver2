using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour, IEnemyHitable
{

    public int Strength=5;
    public int Defense=7;
    public int health=100;
    public int Health { get { return health; }
        set {
            health = value;
            Console.WriteLine("Current Health: "+health);
            if (value <= 0)
                Die();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGetHit(HitType type)
    {
        processHitDamage(type);
    }

    private void processHitDamage(HitType t)
    {
        System.Random gen = new System.Random();
        int damage=0;
        bool hasHit=false;
        int criticalBonus = 1;
        switch (t.Hit) {
            case HitType.FrontalHit:
                hasHit=gen.Next(100) <= 30 ? true : false;
                criticalBonus= gen.Next(100) <= 50 ? 1 : 2;
                damage= gen.Next(5,14);
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
                hasHit =  true;
                damage = gen.Next(1, 8);
                break;
        }
        if(hasHit)
        Health = Health - criticalBonus * damage *(t.Strength / Defense);
    }

    public void Die()
    {
        Destroy(gameObject);
        Console.WriteLine("Goblin died");
    }
}
