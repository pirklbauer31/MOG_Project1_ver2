using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour, IEnemyHitable
{

    public const int STRENGTH = 5;
    public const int DEFFENSE = 50;
    public int Health = 100;

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
        Destroy(gameObject);
    }

    private void processHitDamage(HitType t)
    {
    }
}
