using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BounceHandler
{
    public static readonly float YMINPOSITION = 1f;
    public static readonly float YMAXPOSITION = 5f;

    public static bool CheckOnYValidPosition(float yPosition)
    {
        return yPosition >= YMINPOSITION && yPosition <= YMAXPOSITION;
    }
}
