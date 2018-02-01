using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : BaseGridMovement
{
    public int cellSight = 2;
    public float Sight { get { return cellSize * cellSight; } }
}
