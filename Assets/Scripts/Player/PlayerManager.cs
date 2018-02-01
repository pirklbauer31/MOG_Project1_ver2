using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour,IHitable {

    public bool hasGoldKey = false;
    public bool hasSilverKey = false;
    public int Defense = 20;
    public int health = 100;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (value <= 0)
                Die();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        print("Collision with Player");
        //Pick up gold key
        if (other.gameObject.CompareTag("GoldKey"))
        {
            hasGoldKey = true;
            Destroy(other.gameObject);
            print("Gold Key picked up!");
        }
        else if (other.gameObject.CompareTag("SilverKey"))
        {
            hasSilverKey = true;
            Destroy(other.gameObject);
            print("Silver Key picked up!");
        }

    }

    public void OnGetHit(HitType type)
    {
        print("Player got hit");
        System.Random gen = new System.Random();
        int damage = 0;
        bool hasHit = false;
        int criticalBonus = 1;
        switch (type.Hit)
        {
            case HitType.OrgeHit:
                hasHit = gen.Next(100) <= 30 ? true : false;
                criticalBonus = gen.Next(100) <= 50 ? 1 : 2;
                damage = gen.Next(5, 20);
                break;
            case HitType.GoblinHit:
                hasHit = gen.Next(100) <= 90 ? true : false;
                criticalBonus = gen.Next(100) <= 10 ? 1 : 2;
                damage = gen.Next(1, 12);
                break;
        }
        if (hasHit)
        {
            Health = Health - criticalBonus * damage * (type.Strength / Defense);
            //animator.SetTrigger("damage");
            hasHit = false;
        }
    }

    public void Die()
    {
        //throw new System.NotImplementedException();
    }
}
