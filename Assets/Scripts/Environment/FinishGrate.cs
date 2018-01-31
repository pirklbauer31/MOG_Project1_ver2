using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGrate : MonoBehaviour {

    private BoxCollider collider;

    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        collider = GetComponent<BoxCollider>();

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
		
	}

    private void OnMouseDown()
    {
        gameManager.LevelFinished();

    }
}
