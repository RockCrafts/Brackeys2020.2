using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePoint
{
    public Quaternion rotation;
    public Vector3 position;

    public TimePoint(Vector3 _position, Quaternion _rotation)
    {
        rotation = _rotation;
        position = _position; 
    }
}
