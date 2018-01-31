using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    public int playerHealth = 100;

    private Text playerHPText;

    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        playerHPText = GetComponent<Text>();

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameManager = gameControllerObject.GetComponent<GameManager>();
        }
        if (gameManager == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
        playerHPText.text = playerHealth.ToString();

        if (playerHealth <= 0)
        {
            gameManager.PlayerDead();
        }
	}


}
