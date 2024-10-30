using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DiagnolMovable 
{
    //Rigidbody2D rb { get; set; }
    public delegate void Diagnol();
    public Diagnol moveDiagnol { get; set; }
    protected void MoveDiagnol();
}
