using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseGridMovement
{

    void Update()
    {
        if (IsMoving)
            return;
        else
        {
            if (Input.GetKeyUp("w"))
                StartCoroutine(MoveForward());
            if (Input.GetKeyUp("s"))
                StartCoroutine(MoveBackward());
            if (Input.GetKeyUp("a"))
                StartCoroutine(RotateLeft());
            if (Input.GetKeyUp("d"))
                StartCoroutine(RotateRight());
        }

    }

    public void doMovement(string control)
    {
        if (IsMoving)
            return;
        else
        {
            if (control == "forward")
                StartCoroutine(MoveForward());
            else if (control == "backward")
                StartCoroutine(MoveBackward());
            else if (control == "left")
                StartCoroutine(RotateLeft());
            else if (control == "right")
                StartCoroutine(RotateRight());
        }
    }
}
