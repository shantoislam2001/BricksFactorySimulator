using System;
using UnityEngine;

public class Timer
{
    public float Duration { get; private set; }
    public Action OnComplete { get; private set; }
    public bool IsRunning { get; private set; }

    private float remainingTime;

    public Timer(float duration, Action onComplete)
    {
        Duration = duration;
        remainingTime = duration;
        OnComplete = onComplete;
        IsRunning = true;
    }

    public void Update(float deltaTime)
    {
        if (!IsRunning) return;

        remainingTime -= deltaTime;
        if (remainingTime <= 0f)
        {
            IsRunning = false;
            remainingTime = 0f;
            OnComplete?.Invoke();
        }
    }

    public float GetRemainingTime()
    {
        return remainingTime;
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Stop()
    {
        IsRunning = false;
    }

    public void Reset(float duration)
    {
        Duration = duration;
        remainingTime = duration;
        IsRunning = true;
    }
}
