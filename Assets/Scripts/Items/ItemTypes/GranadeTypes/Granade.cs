using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Granade : MonoBehaviour, IItemThrowable
{
    [SerializeField] protected float radius;
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
  
    public virtual void Throw()
    {

       //granade used
    }

    protected async void OnPointerClicked(Action<Vector2> DoAction)
    {
        while (Input.GetMouseButtonDown(0) == false && !cancellationTokenSource.IsCancellationRequested)
        {
            await Task.Delay(2);
        }
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        DoAction(mouseWorldPosition);

    }

    private void OnDisable()
    {
       cancellationTokenSource.Cancel();
    }

}
