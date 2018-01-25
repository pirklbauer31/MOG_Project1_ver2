using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private bool hasGoldKey = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Pick up gold key
        if (other.gameObject.CompareTag("GoldKey"))
        {
            Destroy(other.gameObject);
        }

    }
}
