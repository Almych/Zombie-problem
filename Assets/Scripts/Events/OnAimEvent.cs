using UnityEngine;

public class OnAimEvent
{
    public bool isAiming { get; private set; }

    public OnAimEvent(bool aim)
    {
        isAiming = aim;
    }
}
