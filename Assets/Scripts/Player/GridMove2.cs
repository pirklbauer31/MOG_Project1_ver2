using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMove2 : MonoBehaviour {

    private bool isMoving = false;
    private int cellSize = 1;
    public float WalkSpeed = 5.0f;
    public float TurnSpeed = 3.5f;
    private AudioSource walkingSound;

    // Use this for initialization
    void Start()
    {
        walkingSound = GetComponent<AudioSource>();
    }

    public void doMovement(string control)
    {
        if (isMoving)
            return;
        else
        {
            if (control == "forward")
            {
                StartCoroutine(MoveForward());
            }
            else if (control == "backward")
            {
                StartCoroutine(MoveBackward());
            }
            else if (control == "left")
            {
                StartCoroutine(RotateLeft());
            }
            else if (control == "right")
            {
                StartCoroutine(RotateRight());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            return;
        else
        {
            if (Input.GetKeyUp("w") )
            {
                StartCoroutine(MoveForward());
            }
            if (Input.GetKeyUp("s"))
            {
                StartCoroutine(MoveBackward());
            }
            if (Input.GetKeyUp("a"))
            {
                StartCoroutine(RotateLeft());
            }
            if (Input.GetKeyUp("d"))
            {
                StartCoroutine(RotateRight());
            }
        }

    }

    /*public void OnGUI()
    {
        if (GUI.Button(new Rect(120, 50, 100, 30), "For"))

            StartCoroutine(MoveForward()); ;

        if (GUI.Button(new Rect(10, 90, 100, 30), "Turn Left"))

            StartCoroutine(RotateLeft());

        if (GUI.Button(new Rect(120, 90, 100, 30), "Back"))

            StartCoroutine(MoveBackward());

        if (GUI.Button(new Rect(230, 90, 100, 30), "Turn Right"))
            StartCoroutine(RotateRight());

    }*/

    IEnumerator MoveForward()
    {
        isMoving = true;
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward * cellSize);
        Collider[] hitColliders = Physics.OverlapSphere(newPos, 0.1f);
        if (hitColliders.Length == 0) {
            walkingSound.Play();
            for (float t=0f;t < 1f; t+= Time.deltaTime * (WalkSpeed / cellSize))
            {
                transform.position = Vector3.Lerp(transform.position, newPos, t);
                yield return new WaitForSeconds(0);
            }
            //transform.Translate(Vector3.forward * cellSize);
        }
        isMoving = false;
    }

    IEnumerator MoveBackward()
    {
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward * -cellSize);
        Collider[] hitColliders = Physics.OverlapSphere(newPos, 0.1f);
        if (hitColliders.Length == 0)
        {
            isMoving = true;
            walkingSound.Play();
            for (float t = 0f; t < 1f; t += Time.deltaTime * (WalkSpeed / cellSize))
            {
                transform.position = Vector3.Lerp(transform.position, newPos, t);
                yield return new WaitForSeconds(0);
            }
        }
        isMoving = false;
    }

    IEnumerator RotateLeft()
    {
        isMoving = true;
        var oldRotation = transform.rotation;
        transform.Rotate(0, -90, 0);
        var NewRotation = transform.rotation;

        for (float t = 0.0f; t <= 1.0f; t += (TurnSpeed * Time.deltaTime))
        {
            transform.rotation = Quaternion.Slerp(oldRotation, NewRotation, t);
            yield return new WaitForSeconds(0);
        }
        //transform.rotation = NewRotation;
        isMoving = false;
    }

    IEnumerator RotateRight()
    {
        isMoving = true;
        var oldRotation = transform.rotation;
        transform.Rotate(0, 90, 0);
        var NewRotation = transform.rotation;

        for (float t = 0.0f; t <= 1.0f; t += (TurnSpeed * Time.deltaTime))
        {
            transform.rotation = Quaternion.Slerp(oldRotation, NewRotation, t);
            yield return new WaitForSeconds(0);
        }
        //transform.rotation = NewRotation;
        //transform.Rotate(0, 90, 0);
        isMoving = false;
    }
}
