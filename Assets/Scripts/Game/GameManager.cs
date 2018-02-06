using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject endText;
    public GameObject deadText;
    public GameObject Player;
    public GameObject RestartButton;
    Subscription<PlayerDead> notificationToken;
    private GameObject[] playerUI;

	// Use this for initialization
	void Start () {
        notificationToken=EventAggregator.SingletionAggregator.Subscribe<PlayerDead>(this.PlayerDead);
        playerUI = GameObject.FindGameObjectsWithTag("PlayerUI");

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void LevelFinished()
    {
        endText.SetActive(true);
        print("Level finished!");
        foreach (GameObject obj in playerUI)
        {
            obj.SetActive(false);
        }
        GameObject.Find("free_sword").SetActive(false);
        RestartButton.SetActive(true);
    }

    public void PlayerDead(PlayerDead d)
    {
        deadText.SetActive(true);
        print("You died!");
        foreach (GameObject obj in playerUI)
        {
            obj.SetActive(false);
        }
        GameObject.Find("free_sword").SetActive(false);
        RestartButton.SetActive(true);
    }

    public void RestartGame()
    {
        print("Button pressed!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
