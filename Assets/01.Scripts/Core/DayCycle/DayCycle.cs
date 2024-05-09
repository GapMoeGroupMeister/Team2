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
    private int _changeDay; 

    public enum Time
    {
        Day, Night
    }
    [SerializeField] private Time currentTime = Time.Day;
    public float Hour = 0;
    [SerializeField] private bool theWorld;

    private void Awake()
    {
        theWorld = false;
        playerObj = Instantiate(playerPrefab);
        playerObj.name.Replace("(Clone)", "");
        combatObj = Instantiate(combatPlayerPrefab);
        combatObj.name.Replace("(Clone)", "");
        PlayDataManager.Instance.LoadPlayData();
        combatObj.SetActive(false);
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
                combatObj.SetActive(false);
                playerObj.SetActive(true);
                currentTime = ChangeDay(currentTime);
                Hour = 0;
                PlayDataManager.Instance.playData._day++;
                PlayDataManager.Instance.playData._fightDay--;
                theWorld = true;
                GoToGameScene();
            }
        }
        else if(currentTime == Time.Day)
        {
            if (Hour > 3f)
            {
                combatObj.SetActive(true);
                playerObj.SetActive(false);
                currentTime = ChangeDay(currentTime);
                Hour = 0;
                theWorld = true;
                GoToGameScene();
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

    public void GoToGameScene()
    {
        SceneManager.LoadScene("ChangeScene");
    }
}


