using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionHandler : IHandlePosition
{
    public Vector3 SetPosition(Vector3 currPosition)
    {
        float randomYPosition =Random.Range(BounceHandler.YMINPOSITION, BounceHandler.YMAXPOSITION);
        Vector3 random = new Vector3(currPosition.x, randomYPosition, currPosition.z);
        return random;
    }
}
