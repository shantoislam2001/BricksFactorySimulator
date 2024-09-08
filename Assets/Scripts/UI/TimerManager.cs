using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private static TimerManager instance;
    private List<Timer> timers = new List<Timer>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        for (int i = timers.Count - 1; i >= 0; i--)
        {
            timers[i].Update(Time.deltaTime);
            if (!timers[i].IsRunning)
            {
                timers.RemoveAt(i);
            }
        }
    }

    public static void AddTimer(Timer timer)
    {
        instance.timers.Add(timer);
    }

    public static void RemoveTimer(Timer timer)
    {
        instance.timers.Remove(timer);
    }
}
