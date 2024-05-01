using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayCycle : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject combatPlayerPrefab;
    GameObject playerObj;
    GameObject combatObj;
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
        //playerObj = Instantiate(playerPrefab);
        //combatObj = Instantiate(combatPlayerPrefab);

        //combatObj.SetActive(false);
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
            if (Hour > 420f)
            {
                combatObj.SetActive(false);
                playerObj.SetActive(true);
                currentTime = ChangeDay(currentTime);
                Hour = 0;
                theWorld = true;
            }
        }
        else if(currentTime == Time.Day)
        {
            if (Hour > 300f)
            {
                combatObj.SetActive(true);
                playerObj.SetActive(false);
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


