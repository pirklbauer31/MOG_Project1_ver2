using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject endText;
    public GameObject deadText;
    public GameObject Player;

    private GridMove2 movement;
    private GameObject[] playerUI;

	// Use this for initialization
	void Start () {
        movement = Player.GetComponent<GridMove2>();
        playerUI = GameObject.FindGameObjectsWithTag("PlayerUI");

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void LevelFinished()
    {
        endText.SetActive(true);
        print("Level finished!");
        movement.enabled = false;
        foreach (GameObject obj in playerUI)
        {
            obj.SetActive(false);
        }
    }

    public void PlayerDead()
    {
        deadText.SetActive(true);
        print("You died!");
        movement.enabled = false;
        foreach (GameObject obj in playerUI)
        {
            obj.SetActive(false);
        }
        GameObject.Find("free_sword").SetActive(false);
    }


}
