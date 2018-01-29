using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public bool hasGoldKey = false;
    public bool hasSilverKey = false;

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
}
