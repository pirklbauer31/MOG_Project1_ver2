using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    private Animator animator;
    private BoxCollider collider;

    public GameObject GUIInfoText;
    private Text guiText;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();

        guiText = GUIInfoText.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GUIInfoText.activeSelf)
        {
            Invoke("hideText", 5f);
        }
    }

    private void OnMouseDown()
    {
        print("Hey you clicked the door!");
        if(GameObject.Find("Player").GetComponent<PlayerManager>().hasSilverKey)
        {
            animator.SetTrigger("dor_open2");
            collider.enabled = false;
        }
        else
        {
            print("Get the Silver key!");
            guiText.text = "You need the silver key!";
            GUIInfoText.SetActive(true);
        }
        
    }

    private void hideText()
    {
        GUIInfoText.SetActive(false);
    }

}
