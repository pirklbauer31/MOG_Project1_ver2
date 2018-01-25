using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private CapsuleCollider coll;
    private AudioSource swordHitSound;
    private Vector2 fingerStart;
    private Vector2 fingerEnd;
    Animator anim;
    public int Strength = 10;
    private bool isHitting;
    private HitType hitType;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<CapsuleCollider>();
        swordHitSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        coll.enabled = false;
        isHitting = false;
        hitType = new HitType(HitType.DefaultHit, Strength);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHitting)
            return;
        if (Input.GetMouseButton(0))
        {
            print("Left click!");
            hitType = new HitType(HitType.TopDownHit, Strength);
            anim.SetTrigger("TopDownAttack");

            //hitType = new HitType(HitType.LeftSideHit, Strength);
            //anim.SetTrigger("LeftSideAttack");

            //hitType = new HitType(HitType.FrontalHit, Strength);
            //anim.SetTrigger("FrontalAttack");

            //hitType = new HitType(HitType.RightSideHit, Strength);
            //anim.SetTrigger("RightSideAttack");


        }
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerStart = touch.position;
                fingerEnd = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                fingerEnd = touch.position;

                if ((fingerStart.x - fingerEnd.x) > 80) // right to left Swipe
                {
                    print("right to left swipe");
                    hitType = new HitType(HitType.RightSideHit, Strength);
                    anim.SetTrigger("RightSideAttack");
                }
                else if ((fingerStart.x - fingerEnd.x) < -80) // left to right Swipe
                {
                    print("left to right swipe");
                    hitType = new HitType(HitType.LeftSideHit, Strength);
                    anim.SetTrigger("LeftSideAttack");
                    //anim.SetTrigger("FrontalAttack");
                }
                else if ((fingerStart.y - fingerEnd.y) < -80) // bottom to top swipe
                {
                    print("Top to bottom swipe");
                    hitType = new HitType(HitType.FrontalHit, Strength);
                    anim.SetTrigger("FrontalAttack");

                }
                else if ((fingerStart.y - fingerEnd.y) > 80) // top to bottom swipe
                {
                    print("Bottom to up swippe");
                    hitType = new HitType(HitType.TopDownHit, Strength);
                    anim.SetTrigger("TopDownAttack");

                }

                //After the checks are performed, set the fingerStart & fingerEnd to be the same
                fingerStart = touch.position;

            }
            if (touch.phase == TouchPhase.Ended)
            {
                fingerStart = Vector2.zero;
                fingerEnd = Vector2.zero;
            }
        }
    }

    public void SetColliderState(int state)
    {
            coll.enabled = (state==1);
    }
    public void SetAnimationState(int state)
    {
        isHitting = (state == 1);
    }


    private void OnTriggerEnter(Collider other)
    {
        swordHitSound.Play();
        //Destroy(other.gameObject);
        print("Collision!");
        if (other.gameObject.GetComponent<IEnemyHitable>() != null)
        {
            coll.enabled = false;
            other.gameObject.SendMessage("OnGetHit", hitType);
        }
        
    }
}
