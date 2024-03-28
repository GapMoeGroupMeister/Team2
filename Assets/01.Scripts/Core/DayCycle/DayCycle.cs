using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public Time currentTime = Time.Day;

    private void Start()
    {
    }
}

public enum Time
{
    Day, Night
}
