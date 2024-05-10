using System.Collections;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    //Managements
    private GameManager _gameManager;
    private WeaponManager _weaponManager;
    
    public PlayerController playerPrefab;
    public PlayerController combatPlayerPrefab;
    [SerializeField] private GameObject _nightVolume;
    [SerializeField] private GameObject _dayVolume;
    PlayerController playerObj;
    PlayerController combatObj;
    public enum Time
    {
        Day, Night
    }
    [SerializeField] private Time currentTime = Time.Day;
    public float Hour = 0;
    [SerializeField] private bool theWorld;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _weaponManager = WeaponManager.Instance;
        
        theWorld = false;
        playerObj = Instantiate(playerPrefab);
        combatObj = Instantiate(combatPlayerPrefab);
        _weaponManager.Init(playerObj.transform.Find("WeaponPos"));

        combatObj.gameObject.SetActive(false);
        _gameManager.PlayerController = playerObj.GetComponent<PlayerController>();
        _gameManager.VirtualCamera.Follow = playerObj.transform;
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
            SpawnSystem.Instance.isSpawn = false;
            SettingDay(false, 42f);
            playerObj.transform.position = combatObj.transform.position;
        }
        else if(currentTime == Time.Day)
        {
            SpawnSystem.Instance.EnemySpawn();
            SettingDay(true, 30f);
            combatObj.transform.position = playerObj.transform.position;
        }

        
    }
    private Time ChangeDay(Time day)
    {
        Time time = Time.Day;
        switch (day)
        {
            case Time.Day:
                time = Time.Night;
                GameManager.Instance.PlayerController = combatObj.GetComponent<PlayerController>();
                GameManager.Instance.VirtualCamera.Follow = combatObj.transform;
                break;
            case Time.Night:
                time = Time.Day;
                GameManager.Instance.PlayerController = playerObj.GetComponent<PlayerController>();
                GameManager.Instance.VirtualCamera.Follow = playerObj.transform;
                break;
        }

        return time;
    }

    private void SettingDay(bool isDay, float hour)
    {
        StartCoroutine(DelayVolumeChange(isDay));
        if (Hour > hour)
        {
            combatObj.gameObject.SetActive(isDay);
            playerObj.gameObject.SetActive(!isDay);
            
            currentTime = ChangeDay(currentTime);
            Hour = 0;
        }
    }

    private IEnumerator DelayVolumeChange(bool isDay)
    {
        if (isDay == false)
        {
            _dayVolume.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            _nightVolume.SetActive(true);
            
        }
        else
        {
            _nightVolume.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            _dayVolume.SetActive(true);
        }
    }
}
