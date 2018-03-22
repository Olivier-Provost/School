using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelTimer
{
    public static int whatever;


    public delegate void parameterlessDelegate();
    parameterlessDelegate funcToCall;

    float countdown = 0;

    public DelTimer(parameterlessDelegate _funcToCall, float timer)
    {
        funcToCall = _funcToCall;
        countdown = timer;
    }

    public bool Update(float dt)
    {
        countdown -= dt;
        if (countdown <= 0)
        {
            try
            {
                funcToCall.Invoke();
            }
            catch
            {
                //FucToInvoke was null because object was probably destroyed
            }
            return true;
        }
        return false;
    }
}
