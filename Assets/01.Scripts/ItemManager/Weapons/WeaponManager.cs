using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    //Managers
    private GameManager _gameManager;
    private InputManager _inputManager;
    private UIManager _uiManager;
    
    [SerializeField] private List<Weapon> _weaponPrefabs = new List<Weapon>();
    [SerializeField] private List<Weapon> _weaponObjList = new List<Weapon>();

    [Space(25)] 
    public List<float> attackDelayTime;
    public List<float> curAttackDelayTime;
    
    [SerializeField] private Weapon _curWeapon;
    public int currentWeapon;
    public Transform WeaponTrm { get; private set; }
    
    private PlayerController player;

    public void Init(Transform weaponTrm)
    {
        _inputManager = InputManager.Instance;
        _gameManager = GameManager.Instance;
        _uiManager = UIManager.Instance;
        player = _gameManager.PlayerController;
        WeaponTrm = weaponTrm;
        WeaponInit();

        _inputManager.ChangeWeaponEvent += ChangeWeapon;
    }

    private void WeaponInit()
    {
        for (int i = 0; i < _weaponPrefabs.Count; ++i)
        {
            Weapon weapon = Instantiate(_weaponPrefabs[i]);
            _weaponObjList.Add(weapon);
            weapon.transform.SetParent(WeaponTrm);
            weapon.transform.localPosition = Vector3.zero;
            _curWeapon = weapon;
            weapon.gameObject.SetActive(i==0);
        }
    }
    
    private void ChangeWeapon()
    {
        currentWeapon = (currentWeapon+1)%_weaponPrefabs.Count;
        _curWeapon = _weaponObjList[currentWeapon];
        
        for (int i = 0; i < _weaponPrefabs.Count; ++i)
        {
            _weaponObjList[i].gameObject.SetActive(i==currentWeapon);
        }

        Sprite iconImage = _weaponObjList[currentWeapon].transform.Find("Visual").GetComponent<SpriteRenderer>().sprite;
        
        _uiManager.SetCurrentWeapon(iconImage);
    }

    private void Update()
    {
        for (int i = 0; i < curAttackDelayTime.Count; ++i)
        {
            if (curAttackDelayTime[i] < attackDelayTime[i])
            {
                curAttackDelayTime[i] += Time.deltaTime;
            }
            else
            {
                _weaponObjList[i].attackable = true;
            }
            if(_weaponObjList[i].attackable == true) continue;
            _uiManager.SetCoolTimeImage(1-(curAttackDelayTime[currentWeapon]/attackDelayTime[currentWeapon]));
        }
    }
}
