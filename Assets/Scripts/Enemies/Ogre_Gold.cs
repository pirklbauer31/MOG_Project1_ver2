﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre_Gold : MonoBehaviour, IEnemyHitable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnGetHitByPlayerMelee (float hitValue)
    {
        Destroy(gameObject);
    }
}
