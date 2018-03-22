using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager
{

    #region singleton
    private static TimerManager instance;

    private TimerManager() { }

    public static TimerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TimerManager();
            }
            return instance;
        }
    }
    #endregion

    List<DelTimer> timerList = new List<DelTimer>();

    public DelTimer AddTimer(DelTimer.parameterlessDelegate funcToInvoke, float countdown)
    {
        DelTimer timer = new DelTimer(funcToInvoke, countdown);
        timerList.Add(timer);
        return timer;
    }

    public void RemoveTimer(DelTimer toRemove)
    {
        timerList.Remove(toRemove);
    }

    public void Update(float dt)
    {
        for (int i = timerList.Count - 1; i >= 0; i--)
            if (timerList[i].Update(dt))
                timerList.RemoveAt(i);
    }

}
