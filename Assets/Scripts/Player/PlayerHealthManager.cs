using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    public int playerHealth = 100;

    private Text playerHPText;

    // Use this for initialization
    void Start () {
        playerHPText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        playerHPText.text = playerHealth.ToString();
	}
}
