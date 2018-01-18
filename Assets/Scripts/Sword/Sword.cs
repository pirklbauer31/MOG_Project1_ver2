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

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<CapsuleCollider>();
        swordHitSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            print("Left click!");
            anim.SetTrigger("TopDownAttack");
            //anim.SetTrigger("FrontalAttack");
            //anim.SetTrigger("SideAttack");

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
                    anim.SetTrigger("SideAttack");
                }
                else if ((fingerStart.x - fingerEnd.x) < -80) // left to right Swipe
                {
                    print("left to right swipe");
                    //anim.SetTrigger("FrontalAttack");
                }
                else if ((fingerStart.y - fingerEnd.y) < -80) // top to bottom swipe
                {
                    print("Top to bottom swipe");
                    anim.SetTrigger("TopDownAttack");

                }
                else if ((fingerStart.y - fingerEnd.y) > 80) // bottom to top swipe
                {
                    print("Bottom to up swippe");
                    anim.SetTrigger("FrontalAttack");

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

    public void setColliderState(int state)
    {
            coll.enabled = (state==1);
    }


    private void OnTriggerEnter(Collider other)
    {
        swordHitSound.Play();
        Destroy(other.gameObject);
        print("Collision!");
        coll.enabled = false;
    }
}
