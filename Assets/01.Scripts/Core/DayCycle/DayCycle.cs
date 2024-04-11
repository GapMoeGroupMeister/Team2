using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour
{
    public enum Time
    {
        Day, Night
    }
    [SerializeField] private Time currentTime = Time.Day;
    public float Hour = 0;
    [SerializeField] private bool theWorld;

    private void Start()
    {
        theWorld = false;
    }

    public bool TheWorld
    {
        get
        {
            return theWorld;
        }   
    }
    private void Update()
    {
        if (theWorld == true) return;

        Hour += UnityEngine.Time.deltaTime;

        if (currentTime == Time.Night)
        {
            if (Hour > 4.2f)
            {
                currentTime = ChangeDay(currentTime);
                Hour = 0;
                theWorld = true;
            }
        }
        else if(currentTime == Time.Day)
        {
            if (Hour > 3f)
            {
                currentTime = ChangeDay(currentTime);
                Hour = 0;
                theWorld = true;
            }
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


