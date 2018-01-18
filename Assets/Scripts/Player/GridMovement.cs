using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    public int MakeMove = 0;
    public bool IsMoving = false;
    public int Facing = 2;
    public float WalkSpeed = 5.0f;
    public float TurnSpeed = 1.5f;
    public float GridSize = 1.5f;
    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private Vector3 old;
    private float t;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (MakeMove == 1 && !IsMoving)
        {
            StartCoroutine(GoForward());
        }

        if (MakeMove == -1 && !IsMoving)
        {
            StartCoroutine(GoBack());
        }

        if (MakeMove == 2 && !IsMoving)
        {
            StartCoroutine(TurnLeft());
        }

        if (MakeMove == -2 && !IsMoving)
        {
            StartCoroutine(TurnRight());
        }

        if (MakeMove == 3 && !IsMoving)
        {
            StartCoroutine(StepLeft());
        }

        if (MakeMove == -3 && !IsMoving)
        {
            StartCoroutine(StepRight());
        }

        if (Input.GetKeyDown("w"))
        {
            MakeMove = 1;
        }
        if (Input.GetKeyDown("s"))
        {
            MakeMove = -1;
        }
        if (Input.GetKeyDown("a"))
        {
            MakeMove = 2;
        }
        if (Input.GetKeyDown("d"))
        {
            MakeMove = -2;
        }
        if (Input.GetKeyDown("q"))
        {
            MakeMove = 3;
        }
        if (Input.GetKeyDown("e"))
        {
            MakeMove = -3;
        }
    }

    public void OnGUI()
    {
        if (GUI.Button(new Rect(120, 50, 100, 30), "Step Forward"))

            MakeMove = 1;

        if (GUI.Button(new Rect(10, 90, 100, 30), "Turn Left"))

            MakeMove = 2;

        if (GUI.Button(new Rect(120, 90, 100, 30), "Step Back"))

            MakeMove = -1;

        if (GUI.Button(new Rect(230, 90, 100, 30), "Turn Right"))
            MakeMove = -2;

        if (GUI.Button(new Rect(10, 50, 100, 30), "Step Left"))
            MakeMove = 3;

        if (GUI.Button(new Rect(230, 50, 100, 30), "Step Right"))
            MakeMove = -3;
    }


    IEnumerator GoForward()
    {
        old = EndPosition;
        MakeMove = 0;
        IsMoving = true;

        StartPosition = transform.position;

        if (Facing == 0)
        {
            EndPosition = transform.position - (new Vector3(0.0f, 0.0f, GridSize));
        }

        if (Facing == 1)
        {
            EndPosition = transform.position - (new Vector3(GridSize, 0.0f, 0.0f));
        }

        if (Facing == 2)
        {
            EndPosition = transform.position - (new Vector3(0.0f, 0.0f, -GridSize));
        }

        if (Facing == 3)
        {
            EndPosition = transform.position - (new Vector3(-GridSize, 0.0f, 0.0f));
        }

        t = 0.0f;

        Collider[] hitColliders = Physics.OverlapSphere(EndPosition, 0.1f);
        if (hitColliders.Length == 0)
        {
            print("TEST");
            while (t < 1.0)
            {
                t += Time.deltaTime * (WalkSpeed / GridSize);
                transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
                yield return new WaitForSeconds(0);
            }
        }
        
        IsMoving = false;
    }


    IEnumerator GoBack()
    {
        old = EndPosition;
        MakeMove = 0;
        IsMoving = true;

        StartPosition = transform.position;

        if (Facing == 0)
            EndPosition = transform.position - (new Vector3(0.0f, 0.0f, -GridSize));

        if (Facing == 1)
            EndPosition = transform.position - (new Vector3(-GridSize, 0.0f, 0.0f));

        if (Facing == 2)
            EndPosition = transform.position - (new Vector3(0.0f, 0.0f, GridSize));

        if (Facing == 3)
            EndPosition = transform.position - (new Vector3(GridSize, 0.0f, 0.0f));

        t = 0.0f;

        while (t < 1.0)
        {
            t += Time.deltaTime * (WalkSpeed / GridSize);
            transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
            yield return new WaitForSeconds(0);
        }

        IsMoving = false;
    }

    IEnumerator StepLeft()
    {
        old = EndPosition;
        MakeMove = 0;
        IsMoving = true;

        StartPosition = transform.position;

        if (Facing == 0)
        {
            EndPosition = transform.position - (new Vector3(-GridSize, 0.0f, 0.0f));
        }

        if (Facing == 1)
        {
            EndPosition = transform.position - (new Vector3(0.0f, 0.0f, GridSize));
        }

        if (Facing == 2)
        {
            EndPosition = transform.position - (new Vector3(GridSize, 0.0f, 0.0f));
        }

        if (Facing == 3)
        {
            EndPosition = transform.position - (new Vector3(0.0f, 0.0f, -GridSize));
        }

        t = 0.0f;

        while (t < 1.0)
        {
            t += Time.deltaTime * (WalkSpeed / GridSize);
            transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
            yield return new WaitForSeconds(0);
        }

        IsMoving = false;
    }

    IEnumerator StepRight()
    {
        old = EndPosition;
        MakeMove = 0;
        IsMoving = true;

        StartPosition = transform.position;

        if (Facing == 0)
        {
            EndPosition = transform.position - (new Vector3(GridSize, 0.0f, 0.0f));
        }

        if (Facing == 1)
        {
            EndPosition = transform.position - (new Vector3(0.0f, 0.0f, -GridSize));
        }

        if (Facing == 2)
        {
            EndPosition = transform.position - (new Vector3(-GridSize, 0.0f, 0.0f));
        }

        if (Facing == 3)
        {
            EndPosition = transform.position - (new Vector3(0.0f, 0.0f, GridSize));
        }

        t = 0.0f;

        while (t < 1.0)
        {
            t += Time.deltaTime * (WalkSpeed / GridSize);
            transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
            yield return new WaitForSeconds(0);
        }

        IsMoving = false;
    }

    IEnumerator TurnLeft()
    {
        MakeMove = 0;
        IsMoving = true;

        Facing -= 1;
        if (Facing < 0)
            Facing = 3;

        var OldRotation = transform.rotation;
        transform.Rotate(0, -90, 0);
        var NewRotation = transform.rotation;

        for (t = 0.0f; t <= 1.0f; t += (TurnSpeed * Time.deltaTime))
        {
            transform.rotation = Quaternion.Slerp(OldRotation, NewRotation, t);
            yield return new WaitForSeconds(0);
        }

        transform.rotation = NewRotation;

        IsMoving = false;
    }

    IEnumerator TurnRight()
    {
        MakeMove = 0;
        IsMoving = true;

        Facing += 1;
        if (Facing > 3)
            Facing = 0;

        var OldRotation = transform.rotation;
        transform.Rotate(0, 90, 0);
        var NewRotation = transform.rotation;

        for (t = 0.0f; t <= 1.0f; t += (TurnSpeed * Time.deltaTime))
        {
            transform.rotation = Quaternion.Slerp(OldRotation, NewRotation, t);
            yield return new WaitForSeconds(0);
        }

        transform.rotation = NewRotation;

        IsMoving = false;
    }

    /*
    public void OnCollisionEnter()
    {
        EndPosition = old;
    }
    */

}
