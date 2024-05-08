using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    //Managers
    private GameManager _gameManager;
    
    [SerializeField] private List<Weapon> _weaponPrefabs = new List<Weapon>();
    [SerializeField] private List<Weapon> _weaponObjList = new List<Weapon>();
    [SerializeField] private Weapon _curWeapon;
    public int currentWeapon;
    [SerializeField] private Transform _weaponTrm;
    
    private PlayerController player;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        player = _gameManager.PlayerController;
        WeaponInit();
    }

    private void WeaponInit()
    {
        for (int i = 0; i < _weaponPrefabs.Count; ++i)
        {
            Weapon weapon = Instantiate(_weaponPrefabs[i]);
            _weaponObjList.Add(weapon);
            weapon.transform.SetParent(_weaponTrm);
            weapon.gameObject.SetActive(i==0);
        }
    }
    
    public void ChangeWeapon()
    {
        currentWeapon++;
    }
    
    public Weapon GetCurrentWeapon()
    {
        return _curWeapon;
    }
}
