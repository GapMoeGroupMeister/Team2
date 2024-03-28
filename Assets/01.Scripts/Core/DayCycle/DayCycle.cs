using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public enum Time
    {
        Day, Night
    }
    public Time currentTime = Time.Day;

    public float Hour = 0;

    private void Start()
    {
        currentTime = ChangeDay(currentTime);
    }

    private void Update()
    {
        Hour += UnityEngine.Time.deltaTime;

        if (Hour > 5)
        {
            
        }
    }

    private Time ChangeDay(Time day)
    {
        Time time = Time.Day;
        switch (day)
        {
            case Time.Day:
                time = Time.Night;
                break;
            case Time.Night:
                time = Time.Day;
                break;
        }

        return time;
    }
}


