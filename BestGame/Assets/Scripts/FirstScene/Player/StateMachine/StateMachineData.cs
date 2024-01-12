using System;
using UnityEngine;

public class StateMachineData
{
    public float YVelocity;
    public float XVelocity;

    private float _speed;
    private float _xInput;

    public float XInput
    {
        get { return _xInput; }
        set
        {
            if (value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _xInput = value;
        }
    }

    public float Speed
    {
        get { return _speed; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }
}
