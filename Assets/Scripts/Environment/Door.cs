using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Animator animator;
    private BoxCollider collider;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        print("Hey you clicked the door!");
        animator.SetTrigger("dor_open2");
        collider.enabled = false;
    }
}
