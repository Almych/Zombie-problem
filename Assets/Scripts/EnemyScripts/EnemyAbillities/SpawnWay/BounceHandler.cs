using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BounceHandler
{
    private const float YMINPOSITION = 1f;
    private const float YMAXPOSITION = 5f;

    public static bool CheckOnYValidPosition(float yPosition)
    {
        return yPosition >= YMINPOSITION && yPosition <= YMAXPOSITION;
    }
}
